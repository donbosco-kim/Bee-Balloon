using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    //testing 
    [SerializeField] private int Damage;

    private GameObject spawnPoint;
    private HealthController healthController;

    



    private void Awake()
    {
        healthController = Camera.main.GetComponent<HealthController>();
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DamagePlayer();
            Destroy(collision.gameObject);
            spawnPoint.SetActive(true);
        }
    }
    void DamagePlayer()
    {
        healthController.playerHealth = healthController.playerHealth - Damage;
        healthController.UpdateHealth();

    }
}
