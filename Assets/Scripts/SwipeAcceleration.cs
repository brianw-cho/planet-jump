using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeAcceleration : MonoBehaviour
{
    private bool swiping = false;
    private bool eventsent = true;
    private Vector2 firstPosition;
    private Vector2 lastPosition;
    private Vector2 tempPosition;
    private Vector2 liveForce = Vector2.zero;
    private Vector2 prevLiveForce = Vector2.zero;
    private Vector2 force;
    public float scale;

    public GameObject[] prefabs;
    private GameObject dottedLine;

    private Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
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
                    gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    break;

                case TouchPhase.Moved:
                    tempPosition = touch.position;
                    liveForce = CalculateForce(tempPosition, firstPosition);
                    swiping = true;
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
            dottedLine.GetComponent<DottedLine>().DrawDottedLine(gameObject.transform.position, liveForce* 0.01f);
        }
        

        if (!eventsent)
        {
            force = CalculateForce(lastPosition, firstPosition);

            if (force.sqrMagnitude != 0)
            {
                rb2D.AddForce(force * scale);
                force = Vector2.zero;
                liveForce = Vector2.zero;
            }
            eventsent = true;
        }
    }

    public Vector2 CalculateForce(Vector2 last, Vector2 first)
    {
        return (last - first) * -1;
    }
}
