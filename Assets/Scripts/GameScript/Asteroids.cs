using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids 
{
    // Start is called before the first frame update

    readonly float wOfPlayer = 1f;
    float wOfField;
    float wOfScreen;
    private float lenOfAsteroid;
    private float spawnPoint;

    public Asteroids(Planet planet)
    {
        wOfField = planet.Field.transform.localScale.x;
        Vector3 screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));
        wOfScreen = screen.x;

        float rangeOfSpawnR = (planet.transform.position.x + (wOfField)/2+ wOfPlayer);
        float rangeOfSpawnL = (planet.transform.position.x - (wOfField/2) - wOfPlayer);
        float[] spawnRange = new float[] {};
        if ((Mathf.Abs(wOfScreen - rangeOfSpawnR)) > (Mathf.Abs(-1*wOfScreen) + rangeOfSpawnL)){
            spawnRange = new float[] {rangeOfSpawnR, wOfScreen};
            spawnPoint = wOfScreen;
        } else if ((Mathf.Abs(wOfScreen - rangeOfSpawnR)) < (Mathf.Abs(-1*wOfScreen) + rangeOfSpawnL)){
            spawnRange = new float[] {-1*wOfScreen, rangeOfSpawnL};
            spawnPoint = wOfScreen * -1;
        }
        
        float MaxlenOfAsteroid = spawnRange[1] - spawnRange[0];
        lenOfAsteroid = Random.Range(1, MaxlenOfAsteroid) * 2;
    }

    public float Length{
        get{return lenOfAsteroid;}
    }

    public float Spawn{
        get{return spawnPoint;}
    }

    public float ScreenWidth
    {
        get { return wOfScreen; }
    }

    public float LeftOrRight()
    {
        if (spawnPoint >= 0)
        {
            return 1f;
        }
        else
        {
            return -1f;
        }
    }
}
