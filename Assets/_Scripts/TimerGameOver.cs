using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerGameOver : MonoBehaviour
{
    private const string RemainingTimeKey = "RemainingTime";
    int initialCountDownValue = 240;
    int countDownValue;
    public TMP_Text timerText;
    bool isTimerRunning;

    // Start is called before the first frame update
    void Start()
    {
        //StartTimer();
        //Check if it's the first level and reset the score
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            ResetTime();
        }
    }

    public void StartTimer()
    {
        isTimerRunning = true;
        // Check if there is a previously stored remaining time
        if (PlayerPrefs.HasKey(RemainingTimeKey))
        {
            countDownValue = PlayerPrefs.GetInt(RemainingTimeKey);
        }
        InvokeRepeating("CountDownTimer", 0.0f, 1.0f);
    }

    void CountDownTimer()
    {
        if (isTimerRunning)
        {
            if (countDownValue > 0)
            {
                // Display the countdown in a 3-2-1 format
                int minutes = countDownValue / 60;
                int seconds = countDownValue % 60;

                timerText.text = string.Format("{0}:{1:00}", minutes, seconds);
                countDownValue--;
                // Save the remaining time to PlayerPrefs
                PlayerPrefs.SetInt(RemainingTimeKey, countDownValue);
                PlayerPrefs.Save();
            }
            else
            {
                isTimerRunning = false; // Stop the timer when it reaches 0
                SceneManager.LoadScene("GameEnd"); // Load game over scene or handle losing logic
                CancelInvoke("CountDownTimer"); // Stop invoking the method when countdown is complete
                // Clear the stored remaining time when the countdown is complete
                PlayerPrefs.DeleteKey(RemainingTimeKey);
            }
        }
    }
    void OnDisable()
    {
        // Ensure that PlayerPrefs data is saved when the script is disabled or the game exits
        PlayerPrefs.Save();
    }
    public void ResetTime()
    {
        
        countDownValue = initialCountDownValue;
        PlayerPrefs.SetInt(RemainingTimeKey, countDownValue);
        PlayerPrefs.Save();
        //StartTimer();
    }

    // Update is called once per frame
    //void Update()
    //{
    // You can add any additional update logic here if needed
    //}
}



