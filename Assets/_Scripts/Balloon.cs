using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public int value; //change the value in Balloon editor. This value represent how many points per balloon

    void Start()
    {
        
    }
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D c2d)
    {
        //Destroy the balloon if Object tagged Player comes in contact with it
        if (c2d.gameObject.CompareTag("Player"))
        {
            //Destroy balloon and increment score
            Camera.main.GetComponent<LevelController>().ballonPickUp(gameObject);
            Destroy(gameObject);
            ScoreCounter.instance.IncreaseCoins(value);
        }
    }
}
