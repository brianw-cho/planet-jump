using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 playerPosition {get; set;}
    public int fuel = 100;
    public int maxFuel = 100;
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
        fuel = maxFuel;
    }

    // Update is called once per frame
    void Update()
    {
        fuelBar.SetFuel(fuel);
        if (fuel > maxFuel)
        {
            fuel = maxFuel;
        }
    }

    void FixedUpdate(){
        if (!onPlanet)
        {
            var pos = transform.position;
            transform.position = new Vector3(pos.x, pos.y - 0.01f, pos.z);
        }
    }

    public void DecreaseFuel(int amount)
    {
        fuel = fuel - (int)(amount * fuelScale);
        fuelBar.SetFuel(fuel);
    }

    // public  Vector3 getPosition(){
    //     return transform.position;
    // }

    
}
