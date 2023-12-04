using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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
        //Load the score from PlayerPrefs when the game starts
        currentScores = PlayerPrefs.GetInt("Score", 0);
        UpdateScoreText();
        //Check if it's the first level and reset the score
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            ResetScore();
        }

    }
    public void IncreaseCoins(int v)
    {
        currentScores += v;
        UpdateScoreText();
        
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + currentScores.ToString();
    }

    //Save the score to PlayerPrefs when the script is disabled (e.g., when switching scenes)
    public void OnDisable()
    {
        PlayerPrefs.SetInt("Score", currentScores);
        PlayerPrefs.Save();
    }
    //Reset the score
    public void ResetScore()
    {
        currentScores = 0;
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.Save();
        UpdateScoreText();
    }
}
