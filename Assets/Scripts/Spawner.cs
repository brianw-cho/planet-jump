using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;   
    void Start()
    {
        StartCoroutine (PlanetGenerator());
    }

    IEnumerator PlanetGenerator()
    {
        yield return new WaitForSeconds(0);

        var planetPosition = transform;
        Instantiate(prefabs[0]);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
