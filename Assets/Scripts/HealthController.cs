using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;


    public void Hit(float damage) 
    {
        currentHealth -= damage;
    }
}
