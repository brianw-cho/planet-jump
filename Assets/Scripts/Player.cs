using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 playerPosition {get; set;}
    public float fuel;
    public float maxFuel;
    public float fuelScale;
    public bool onPlanet{get; set;} = false;
    static public Player s_Singleton;
    public FuelBar fuelBar;

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
        
    }

    void FixedUpdate(){
        if (!onPlanet)
        {
            var pos = transform.position;
            transform.position = new Vector3(pos.x, pos.y - 0.01f, pos.z);
        }
    }

    public void DecreaseFuel(float amount)
    {
        fuel = fuel - (amount * fuelScale);
        fuelBar.SetFuel(fuel);
    }

    // public  Vector3 getPosition(){
    //     return transform.position;
    // }

    
}
