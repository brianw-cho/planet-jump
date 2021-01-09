using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotateScale;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var pos = transform.rotation;
        transform.Rotate(new Vector3(pos.x, pos.y, pos.z + rotateScale)*Time.deltaTime);
    }
}
