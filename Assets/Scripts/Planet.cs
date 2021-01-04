using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float rotationAdder;
    Vector3 planetPosition {get; set;}
    Vector3 size;
    Collider2D touchPlayer;
    public Transform player;
    private Vector3 directionofPlayer;
    public float gravity;

    

    // Start is called before the first frame update
    void Start()
    {
        planetPosition = transform.position;
        touchPlayer = GetComponent<Collider2D>();

        float randNum = Random.Range(3f,6f);
        size = new Vector3(randNum, randNum, 1f);
        transform.localScale = size;
    }

    // Update is called once per frame
    void Update()
    {
        rotation();
    }

    private void FixedUpdate()
    {
        directionofPlayer = (transform.position - player.position).normalized;
    }

    private void OnTriggerStay2D (Collider2D touchPlayer)
    {
        print("collision!");
        player.GetComponent<Rigidbody2D>().AddForce(directionofPlayer * gravity);
    }

    void rotation(){
        var pos = transform.rotation;
        transform.Rotate(new Vector3(pos.x, pos.y, pos.z + rotationAdder)*Time.deltaTime);
    }
}
