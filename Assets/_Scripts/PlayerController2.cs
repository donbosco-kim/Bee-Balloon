using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{

    private Camera mainCam;
    private Vector3 offset;
    private bool Active = true;
    [SerializeField] float speed = 1.0f;


    void Start()
    {
        mainCam = Camera.main;
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        if (Active)
        {
            Vector2 worldPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.MoveTowards(transform.position, worldPos, Time.deltaTime * speed);
        }
    }
}



