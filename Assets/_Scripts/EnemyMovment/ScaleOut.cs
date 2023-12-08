using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FadeOut : MonoBehaviour
{


    [Header("Axes to be Scaled")]
    public bool x = true;
    public bool y = false;

    [Header("Scale Change Per Second")]
    [Range(0f,50f)]
    public float changePerSecond = 1f;

    [Header("Time to wait Before Scaling in Other Direction (Seconds)")]
    [Range(0f,50f)]
    public float sleepTime = 3f;

    private float xMax;
    private float yMax;

    private bool scaleUpCheck = false;
    private bool scaleDownCheck = true;
    


    // Start is called before the first frame update
    void Start()
    {
        xMax = transform.localScale.x;
        yMax = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {


        if (scaleUpCheck)
        {
            Scale(1);
        }
        else if (scaleDownCheck)
        {
            Scale(-1);
        }

        StartCoroutine(ScaleDownEndCheck());
        StartCoroutine(ScaleUpEndCheck());

    }



     


    private void Scale(int direction)
    {
        if (x)
        {

            float newScale = transform.localScale.x + (changePerSecond * direction) * Time.deltaTime;
            Debug.Log(newScale);


            if(newScale < 0)
            {
                newScale = 0;
            }
            else if(newScale > xMax)
            {
                newScale = xMax;
            }
            transform.localScale = new Vector3(newScale, transform.localScale.y, transform.localScale.z);
            
        }
        if (y)
        {
            float newScale = transform.localScale.y + (changePerSecond * direction) * Time.deltaTime;

            if (newScale < 0)
            {
                newScale = 0;
            }
            else if (newScale > yMax)
            {
                newScale = yMax;
            }
            transform.localScale = new Vector3(transform.localScale.x, newScale, transform.localScale.z);
        }
    }




    private IEnumerator ScaleDownEndCheck()
    {
        if (scaleDownCheck)
        {
            if (x && !y)
            {
                if (transform.localScale.x == 0)
                {
                    scaleDownCheck = false;
                    yield return new WaitForSeconds(sleepTime);
                    scaleUpCheck = true;
                }
            }

            if (!x && y)
            {
                if (transform.localScale.y == 0)
                {
                    scaleDownCheck = false;
                    yield return new WaitForSeconds(sleepTime);
                    scaleUpCheck = true;
                }
            }

            if (x && y)
            {
                if (transform.localScale.y == 0 && transform.localScale.x == 0)
                {
                    scaleDownCheck = false;
                    yield return new WaitForSeconds(sleepTime);
                    scaleUpCheck = true;
                }
            }
        }
        
    }

    private IEnumerator ScaleUpEndCheck()
    {
        if (scaleUpCheck)
        {
            if (x && !y)
            {
                if (transform.localScale.x == xMax)
                {
                    scaleUpCheck = false;
                    yield return new WaitForSeconds(sleepTime);
                    scaleDownCheck = true;
                }
            }

            if (!x && y)
            {
                if (transform.localScale.y == yMax)
                {
                    scaleUpCheck = false;
                    yield return new WaitForSeconds(sleepTime);
                    scaleDownCheck = true;
                }
            }

            if (x && y)
            {
                if (transform.localScale.y == yMax && transform.localScale.x == xMax)
                {
                    scaleUpCheck = false;
                    yield return new WaitForSeconds(sleepTime);
                    scaleDownCheck = true;
                }
            }
        }

    }


}



