using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;
    float delay = 0f;   
    void Start()
    {
        StartCoroutine (PlanetGenerator());
    }

    IEnumerator PlanetGenerator()
    {
        yield return new WaitForSeconds(delay);

        float xPos = Random.Range(-3f,3f);
        Vector3 position = new Vector3(xPos, 0, 0);
        Instantiate(prefabs[0], position, Quaternion.identity);

        if (delay == 0f){
            delay+=10;
        }
        StartCoroutine(PlanetGenerator());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
