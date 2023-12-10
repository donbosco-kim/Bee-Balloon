using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnPoint: MonoBehaviour
{

    [SerializeField] private GameObject PlayerPrefab;
    [SerializeField] private Timer timer;

    public void OnStartClick()
    {
       GameObject GO = GameObject.Instantiate(PlayerPrefab);
        GO.transform.position = transform.position;
        gameObject.SetActive(false);
        //Start the timer when the button is clicked
        timer.StartTimer();
    }
}
