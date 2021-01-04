using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float rotationAdder;
    Vector3 planetPosition {get; set;}

    // Start is called before the first frame update
    void Start()
    {
        planetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        rotation();
    }

    void rotation(){
        var pos = transform.rotation;
        transform.Rotate(new Vector3(pos.x, pos.y, pos.z + rotationAdder)*Time.deltaTime);
    }
}
