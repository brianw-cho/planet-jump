using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetChild : MonoBehaviour
{
    public Transform player;
    public Transform planet;
    private Collider2D touchPlayer;
    public bool isChild { get; set; } = false;

    void Awake()
    {
        player = gameObject.GetComponentInParent<Planet>().player;
        planet = gameObject.transform.parent;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D (Collider2D touchplayer)
    {
        isChild = true;
        player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        player.transform.SetParent(planet);
    }

    private void OnTriggerStay2D (Collider2D touchplayer)
    {

    }

    private void OnTriggerExit2D (Collider2D touchplayer)
    {
        isChild = false;
        player.transform.SetParent(null);
    }
}
