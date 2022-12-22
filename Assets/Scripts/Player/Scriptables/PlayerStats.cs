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
    public int currentStamina;

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
    }
}
