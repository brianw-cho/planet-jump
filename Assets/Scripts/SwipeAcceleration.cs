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
    public float scale;

    private Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
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
                    break;

                case TouchPhase.Moved:
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

        if (!eventsent)
        {
            Vector2 force = CalculateForce();

            if (force.sqrMagnitude != 0)
            {
                rb2D.AddForce(force * scale);
                force = new Vector2(0f, 0f);
            }
            eventsent = true;
        }
    }

    public Vector2 CalculateForce()
    {
        return lastPosition - firstPosition;
    }
}
