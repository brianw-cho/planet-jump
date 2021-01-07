using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeAcceleration : MonoBehaviour
{
    private bool swiping = false;
    private bool eventsent = true;
    private Vector2 firstPosition;
    private Vector2 firstPosition_w;
    private Vector2 lastPosition;
    private Vector2 tempPosition_w;
    private Vector2 tempPosition;
    private Vector2 transLastPos;
    private Vector2 force;
    public float scale;

    public GameObject[] prefabs;
    private GameObject dottedLine;
    private Camera cam;

    private Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        dottedLine = Instantiate(prefabs[0]);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    firstPosition = touch.position;
                    firstPosition_w = cam.ScreenToWorldPoint(firstPosition);
                    gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    break;

                case TouchPhase.Moved:
                    swiping = true;
                    tempPosition = touch.position;
                    tempPosition_w = cam.ScreenToWorldPoint(tempPosition);
                    transLastPos = translateVector(tempPosition_w);
                    break;

                case TouchPhase.Ended:
                    if (swiping)
                    {
                        lastPosition = touch.position;
                        swiping = false;
                        eventsent = false;
                    }
                    break;
            }
        }

        if (swiping)
        {
            dottedLine.GetComponent<DottedLine>().DrawDottedLine(gameObject.transform.position, transLastPos);
        }
        

        if (!eventsent)
        {
            force = CalculateForce(lastPosition, firstPosition);

            if (force.sqrMagnitude != 0)
            {
                rb2D.AddForce(force * scale);
                force = Vector2.zero;
            }
            eventsent = true;
        }
    }

    public Vector2 CalculateForce(Vector2 last, Vector2 first)
    {
        return (last - first) * -1;
    }

    public Vector2 translateVector(Vector2 endpoint)
    {
        Vector2 original = endpoint + (Vector2)gameObject.transform.position - firstPosition_w;
        return (Vector2)gameObject.transform.position - (original - (Vector2)gameObject.transform.position);
    }
}
