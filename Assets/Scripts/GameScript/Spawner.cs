using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;
    float delay = 0f;
    void Start()
    {
        StartCoroutine(ObstacleGenerator());
    }
    IEnumerator ObstacleGenerator()
    {
        yield return new WaitForSeconds(delay);

        float xPos = Random.Range(-3f, 3f);
        Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height + 400, 0));
        position.x = xPos;
        position.z = 0;
        Instantiate(prefabs[0], position, Quaternion.identity);

        if (delay == 0f)
        {
            delay += 10;
        }
        StartCoroutine(ObstacleGenerator());
    }
    // Update is called once per frame
    void Update()
    {

    }
}
