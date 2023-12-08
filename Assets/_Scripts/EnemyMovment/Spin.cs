using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [Range(0,200)]
    public float speed = 10f;

    [Range(-1,1)]
    public int direction = 1;



    // Update is called once per frame
    void Update()
    {
        transform.Rotate((Vector3.forward * direction)* Time.deltaTime * speed, Space.Self);
    }
}
