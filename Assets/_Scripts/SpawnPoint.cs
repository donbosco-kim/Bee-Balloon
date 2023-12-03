using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnPoint: MonoBehaviour
{

    [SerializeField] private GameObject PlayerPrefab;

    public void OnStartClick()
    {
       GameObject GO = GameObject.Instantiate(PlayerPrefab);
        GO.transform.position = transform.position;
        gameObject.SetActive(false);
    }
}
