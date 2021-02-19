using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float rotationAdder;
    public float speed = 0.01f;
    Vector3 planetPosition { get; set; }
    Vector3 size;
    CircleCollider2D touchPlayer;
    public Transform player;
    private Vector3 directionofPlayer;
    public float gravity;
    GameObject field;
    GameObject asteroidGObj;
    public GameObject[] prefabs;

    public Asteroids asteroid;
    private List<int> asteroids = new List<int>();
    private GameObject[] asteroids_go;
    private float[] lenOfAsteroids = new float[] { 1.5f, 1.2f, 1.2f, 1.0f };
    public Sprite[] planetSprite;


    public GameObject Field
    {
        get { return field; }
        set { field = value; }
    }

    void Awake()
    {
        player = Player.s_Singleton.gameObject.transform;
        int planetSpriteRandomizer = Random.Range(0, planetSprite.Length);
        GetComponent<SpriteRenderer>().sprite = planetSprite[planetSpriteRandomizer];
    }


    // Start is called before the first frame update
    void Start()
    {
        float randNum = Random.Range(1f, 3f);
        size = new Vector3(randNum, randNum, 1f);
        transform.localScale = size;

        planetPosition = transform.position;
        touchPlayer = GetComponent<CircleCollider2D>();

        field = Instantiate(prefabs[0], transform.position, transform.rotation);
        field.transform.localScale = new Vector3(transform.localScale.x * (1.35F / 0.5F), transform.localScale.y * (1.35F / 0.5F), transform.localScale.z * (1.35F / 0.5F));

        Planet planet = gameObject.GetComponent<Planet>();
        asteroid = new Asteroids(planet);
        FitAsteroid(asteroid);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 objScreenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (objScreenPos.y < -500)
        {
            if (asteroids.Count > 0)
            {
                for (int i = 0; i < asteroids_go.Length; i++)
                {
                    Destroy(asteroids_go[i]);
                }
            }
            Destroy(gameObject);
            Destroy(field);
        }

        speed = player.GetComponent<Player>().speed;
    }

    private void FixedUpdate()
    {
        directionofPlayer = (transform.position - player.position).normalized;

        rotation();

        var pos = transform.position;
        transform.position = new Vector3(pos.x, pos.y - speed, pos.z);
        field.transform.position = transform.position;

        if (asteroids.Count > 0)
        {
            for (int i = 0; i < asteroids_go.Length; i++)
            {
                var asPos = asteroids_go[i].transform.position;
                asteroids_go[i].transform.position = new Vector3(asPos.x, asPos.y - speed, asPos.z);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D touchplayer)
    {
        if (touchplayer.gameObject.name == "Player")
        {
            if (!gameObject.GetComponentInChildren<PlanetChild>().isChild)
            {
                player.GetComponent<Rigidbody2D>().AddForce(directionofPlayer * gravity);
            }
        }

    }

    void rotation()
    {
        var pos = transform.rotation;
        transform.Rotate(new Vector3(pos.x, pos.y, pos.z + rotationAdder) * Time.deltaTime);
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    void FitAsteroid(Asteroids asteroid)
    {
        float asteroidLength = 0;
        int randomAsteroid;

        do
        {
            randomAsteroid = Random.Range(0, 4);
            asteroidLength += lenOfAsteroids[randomAsteroid];
            asteroids.Add(randomAsteroid + 1);
        } while (asteroidLength < asteroid.Length);

        asteroids.RemoveAt(asteroids.Count - 1);

        if (asteroids.Count == 0)
        {
            return;
        }


        float[] posOfAsteroids = new float[asteroids.Count];

        if (asteroid.LeftOrRight() > 0)
        {
            posOfAsteroids[0] = (asteroid.ScreenWidth * asteroid.LeftOrRight()) - (lenOfAsteroids[asteroids[0] - 1] / 2);
        }
        else
        {
            posOfAsteroids[0] = (asteroid.ScreenWidth * asteroid.LeftOrRight()) + (lenOfAsteroids[asteroids[0] - 1]/ 2);
        }


        for (int i = 1; i < asteroids.Count; i++)
        {
            if (asteroid.LeftOrRight() > 0) 
            {
                posOfAsteroids[i] = posOfAsteroids[i - 1] - (lenOfAsteroids[asteroids[i - 1] - 1] / 2) - (lenOfAsteroids[asteroids[i] - 1] / 2);
            }
            else
            {
                posOfAsteroids[i] = posOfAsteroids[i - 1] + (lenOfAsteroids[asteroids[i - 1] - 1] / 2) + (lenOfAsteroids[asteroids[i] - 1] / 2);
            }
        }


        Vector3 location;
        asteroids_go = new GameObject[asteroids.Count];

        for (int i = 0; i < asteroids.Count; i++)
        {
            location = new Vector3(posOfAsteroids[i], transform.position.y, transform.position.z);
            asteroids_go[i] = Instantiate(prefabs[asteroids[i]], location, transform.rotation);
        }
    }
}
