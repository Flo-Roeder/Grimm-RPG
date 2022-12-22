using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] HealthUI healthUI;
    public int armor;

    [Header("Optional / just Player")]
    public float maxStamina;
    public float currentStamina;
    public bool canDash = true;

    [SerializeField] bool isPlayer;
    Animator anim;

    [SerializeField] PlayerStats playerStats;

    private void Awake()
    {
        currentStamina = maxStamina;
        playerStats.currentHealth=playerStats.maxHealth;
        anim = GetComponentInParent<Animator>();
    }

    private void Start()
    {
        if (healthUI != null)
        {
            healthUI.SetHealthUI(playerStats.maxHealth, playerStats.currentHealth, isPlayer);
        }

    }

    private void Update()
    {
        currentStamina = currentStamina < maxStamina ? currentStamina + Time.deltaTime * 10 : maxStamina;
    }


    public void Hit(int _damage)
    {
        _damage = _damage - armor > 0 ? _damage - armor : 0;
        playerStats.currentHealth -= _damage;
        anim.SetTrigger(AnimStrings.isHit);
        Death();
        healthUI.SetHealthUI(playerStats.maxHealth, playerStats.currentHealth, isPlayer);
    }
    public void Heal(int heal)
    {
        if (playerStats.currentHealth < playerStats.maxHealth)
        {
            playerStats.currentHealth += heal;
        }
        else
        {
            playerStats.currentHealth = playerStats.maxHealth;
        }
        healthUI.SetHealthUI(playerStats.maxHealth, playerStats.currentHealth, isPlayer);
    }

    public void TakeStamina(float staminaReduce, bool playerCanDash)
    {
        currentStamina -= staminaReduce;
        canDash = playerCanDash;
    }

    public void TakeStamina(float staminaReduce)
    {
        currentStamina -= staminaReduce;
    }

    void Death()
    {
        if (playerStats.currentHealth <= 0)
        {
            //TODO death animation
            //DeathEventTrigger?.Invoke();
            gameObject.GetComponentInParent<Rigidbody2D>().gameObject.SetActive(false);
        }
    }

}
