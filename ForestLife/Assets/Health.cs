using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float healthAmount = 100;
    void Start()
    {
        gameObject.tag = "Player";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Healing(10);
        }
    }

    public void TakeDamage(float Damage)
    {
        healthAmount -= Damage;

        if (healthAmount <= 0)
        {
            Destroy(gameObject);
        }

        Debug.Log("Hit");
            
    }

    public void Healing(float healPoints)
    {
        healthAmount += healPoints;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
    }
}
