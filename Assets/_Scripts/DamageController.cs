using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    //testing 
    [SerializeField] private int starDamage;

    [SerializeField] private HealthController healthController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Damage();
        }
    }
    void Damage()
    {
        healthController.playerHealth = healthController.playerHealth - starDamage;
        healthController.UpdateHealth();
        gameObject.SetActive(false);
    }
}
