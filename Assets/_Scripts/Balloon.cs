using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Balloon : MonoBehaviour
{
    public int value; //change the value in Balloon editor. This value represent how many points per balloon

    Animator m_Animator;
    float sleepTime = .5f;

    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
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
            m_Animator.SetTrigger("pop");
            ScoreCounter.instance.IncreaseCoins(value);
            StartCoroutine(Destroytimer());
        }
    }



    private IEnumerator Destroytimer()
    {
        yield return new WaitForSeconds(sleepTime);
        Destroy(gameObject);
    }


}
