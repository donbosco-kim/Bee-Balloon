using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter instance;

    public TMP_Text scoreText;
    public int currentScores = 0;

    void Awake()
    {
        instance = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + currentScores.ToString();
    }
    public void IncreaseCoins(int v)
    {
        currentScores += v;
        scoreText.text = "Score: " + currentScores.ToString();
    }
}
