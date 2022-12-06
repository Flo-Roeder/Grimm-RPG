using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public float maxStamina;
    public float currentStamina;
    public bool canDash = true;

    [SerializeField] HealthUI healthUI;

    private void Awake()
    {
        currentHealth = maxHealth;
        currentStamina= maxStamina;
    }

    private void Start()
    {
        healthUI.SetHealthUI(maxHealth,currentHealth);
    }

    private void Update()
    {
        currentStamina = currentStamina < maxStamina ? currentStamina + Time.deltaTime*10 : maxStamina;
        healthUI.SetStaminaUI(maxStamina,currentStamina,canDash);
    }


    public void Hit(float damage) 
    {
        currentHealth -= damage;
        healthUI.SetHealthUI(maxHealth,currentHealth);
    }

    public void TakeStamina(float staminaReduce, bool playerCanDash)
    {
        currentStamina-= staminaReduce;
        canDash = playerCanDash;
    }

    public void TakeStamina(float staminaReduce)
    {
        currentStamina-= staminaReduce;
    }
}
