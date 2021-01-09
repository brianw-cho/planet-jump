using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float rotationAdder;
    Vector3 planetPosition {get; set;}
    Vector3 size;
    CircleCollider2D touchPlayer;
    public Transform player;
    private Vector3 directionofPlayer;
    public float gravity;
    GameObject field;
    GameObject asteroidGObj;
    public GameObject[] prefabs;

    public Asteroids asteroids;
    public Sprite[] planetSprite;
    

    public GameObject Field{
        get{return field;}
        set{field = value;}
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
        float randNum = Random.Range(1f,3f);
        size = new Vector3(randNum, randNum, 1f);
        transform.localScale = size;

        planetPosition = transform.position;
        touchPlayer = GetComponent<CircleCollider2D>();

        field = Instantiate(prefabs[0], transform.position, transform.rotation );
        field.transform.localScale = new Vector3(transform.localScale.x*(1.35F/0.5F), transform.localScale.y*(1.35F/0.5F), transform.localScale.z*(1.35F/0.5F));

        Planet planet = gameObject.GetComponent<Planet>();
        asteroids = new Asteroids(planet);
        Vector3 location = new Vector3(asteroids.Spawn, transform.position.y, transform.position.z);
        asteroidGObj = Instantiate(prefabs[1],location, transform.rotation);
        asteroidGObj.transform.localScale = new Vector3(asteroids.Length, asteroidGObj.transform.localScale.y, asteroidGObj.transform.localScale.z) ;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 objScreenPos = Camera.main.WorldToScreenPoint (transform.position); 
        if (objScreenPos.y < -500){
            Destroy(gameObject);
            Destroy(field);
        }
    }

    private void FixedUpdate()
    {
        directionofPlayer = (transform.position - player.position).normalized;

        rotation();

        var pos = transform.position;
        transform.position = new Vector3(pos.x, pos.y - 0.01f, pos.z);
        field.transform.position = transform.position;

        var asPos = asteroidGObj.transform.position;
        asteroidGObj.transform.position = new Vector3(asPos.x, asPos.y - 0.01f, asPos.z);
    }

    private void OnTriggerStay2D (Collider2D touchplayer)
    {
        if (touchplayer.gameObject.name == "Player"){
            if (!gameObject.GetComponentInChildren<PlanetChild>().isChild)
            {
                player.GetComponent<Rigidbody2D>().AddForce(directionofPlayer * gravity);
            }
        }

    }

    void rotation(){
        var pos = transform.rotation;
        transform.Rotate(new Vector3(pos.x, pos.y, pos.z + rotationAdder)*Time.deltaTime);
    }
}
