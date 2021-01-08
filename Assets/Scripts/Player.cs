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

        if (Camera.main.WorldToScreenPoint(transform.position).x == Screen.width  || 
        Camera.main.WorldToScreenPoint(transform.position).x == 0 ||
        Camera.main.WorldToScreenPoint(transform.position).y == Screen.height ||
        Camera.main.WorldToScreenPoint(transform.position).y == 0) {
            lose();
        }
    }

     private void OnTriggerEnter2D (Collider2D touchAsteroids){
         if (touchAsteroids.gameObject.name == "Asteroids(Clone)"){
            lose();
         }
     }
    public void DecreaseFuel(int amount)
    {
        fuel = fuel - (int)(amount * fuelScale);
        fuelBar.SetFuel(fuel);
    }

    void lose(){
        print("You lose");
    }
    // public  Vector3 getPosition(){
    //     return transform.position;
    // }

    
}
