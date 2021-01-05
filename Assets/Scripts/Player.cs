using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 playerPosition {get; set;} 
    bool onPlanet{get; set;} = true;
    static public Player s_Singleton;

    void Awake()
    {
        s_Singleton = this;
    }

    void Start()
    {
        playerPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        transform.position = new Vector3(pos.x, pos.y - 0.01f, pos.z);
    }

    // public  Vector3 getPosition(){
    //     return transform.position;
    // }

    
}
