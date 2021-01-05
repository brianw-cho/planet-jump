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

        var planetPosition = transform;
        Instantiate(prefabs[0]);

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
