using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 playerPosition {get; set;} 
    bool onPlanet{get; set;} = true;

    void Start()
    {
        playerPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // public  Vector3 getPosition(){
    //     return transform.position;
    // }

    
}
