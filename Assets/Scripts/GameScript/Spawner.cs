using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float maxDistance;
    public GameObject[] prefabs;
    float delay = 0f;
    public Player player;
    GameObject planet;
    Vector3 position;
    void Start()
    {
        position = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height + 400, 0));
        player = Player.s_Singleton.gameObject.GetComponent<Player>();
        spawnPlanet();

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (position.y - planet.transform.position.y > maxDistance)
        {
            spawnPlanet();
        }
    }

    void spawnPlanet()
    {
        float xPos = Random.Range(-2.5f, 2.5f);
        position.x = xPos;
        position.z = 0;
        planet = Instantiate(prefabs[0], position, Quaternion.identity);
        planet.GetComponent<Planet>().SetSpeed(player.speed);
    }
}
