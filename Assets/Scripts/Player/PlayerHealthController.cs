using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] HealthUI healthUI;
    public int armor;

    [Header("Optional / just Player")]
    public bool canDash = true;

    [SerializeField] bool isPlayer;
    Animator anim;

    public PlayerStats playerStats;


    private void Awake()
    {
        playerStats.currentHealth = playerStats.maxHealth;
        playerStats.currentStamina= playerStats.maxStamina;
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
        playerStats.currentStamina = (playerStats.currentStamina < playerStats.maxStamina ? playerStats.currentStamina + Time.deltaTime * playerStats.regenStamina : playerStats.maxStamina);
        healthUI.SetStaminaUI(playerStats.maxStamina, playerStats.currentStamina, canDash);

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

    public void TakeStamina(int staminaReduce, bool playerCanDash)
    {
        playerStats.currentStamina -= staminaReduce;
        canDash = playerCanDash;
    }

    public void TakeStamina(int staminaReduce)
    {
        playerStats.currentStamina -= staminaReduce;

    }

    void Death()
    {
        if (playerStats.currentHealth <= 0)
        {
            //TODO death animation
            //DeathEventTrigger?.Invoke();
            gameObject.GetComponentInParent<Rigidbody2D>().gameObject.SetActive(false);
            SceneManager.LoadScene(0);
        }
    }

}
