using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public int maxHealth;
    public int currentHealth;

    public int armor;

    public int maxStamina;
    public float currentStamina;
    public float regenStamina;

    public float moveSpeed;
    public float dashSpeed;
    public float dashTime;
    public float dashCooldown;
    public float dashStaminaCost;

    public int attackDamage;
    public int critChancePercentage;
    public float critMultiplier;
    public float attackStaminaCost;

    public float knockbackAmount;
    public float knockbackTime;

    private void Awake()
    {
        currentHealth = maxHealth;
        currentStamina= maxStamina;
    }

    public void MaxHealthChange(int value)
    {
        maxHealth += value;
        GameObject.FindGameObjectWithTag("HealthUI").GetComponent<HealthUI>().SetHealthUI(maxHealth,currentHealth,true);

    }

    public void ArmorChange(int value)
    {
        armor += value;
    }

    public void MaxStaminaChange(int value)
    {
        maxStamina += value;
        GameObject.FindGameObjectWithTag("HealthUI").GetComponent<HealthUI>().SetStaminaUI(maxStamina,currentStamina,true);

    }

    public void RegenStaminaChange(int value)
    {
        regenStamina += value;
    }

    public void MoveSpeedChange(int value)
    {
        moveSpeed += value;
    }


    public void DashSpeedChange(int value)
    {
        dashSpeed += value;
    }


    public void DashCooldownChange(float value)
    {
        dashCooldown += value;
    }


    public void DashStaminaCostChange(int value)
    {
        dashStaminaCost += value;
    }

    public void AttackDamageChange(int value)
    {
        attackDamage += value;
    }

    public void CritChanceChange(int value)
    {
        critChancePercentage += value;
    }

    public void CritMultiChange(float value)
    {
        critMultiplier += value;
    }

    public void AttackStaminaCost(int value)
    {
        attackStaminaCost += value;
    }

    public void KnockbackAmountChange(int value)
    {
        knockbackAmount += value;
    }

    public void KnockbackTimeChange(float value)
    {
        knockbackTime += value;
    }

}
