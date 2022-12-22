using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    [SerializeField] HealthUI healthUI;
    public int armor;

    [Header("Optional / just Player")]
    public float maxStamina;
    public float currentStamina;
    public bool canDash = true;

    [SerializeField] bool isPlayer;
    Animator anim;

    public delegate void DeathEvent();
    public static event DeathEvent DeathEventTrigger;

    private void Awake()
    {
        currentHealth = maxHealth;
        currentStamina= maxStamina;
        anim= GetComponentInParent<Animator>();
        DeathEventTrigger = null;
    }

    private void Start()
    {
        if (healthUI!=null)
        {
        healthUI.SetHealthUI(maxHealth,currentHealth,isPlayer);

        }
    }

    private void Update()
    {
        currentStamina = currentStamina < maxStamina ? currentStamina + Time.deltaTime*10 : maxStamina;
        if (healthUI!=null
            && isPlayer)
        {
        healthUI.SetStaminaUI(maxStamina,currentStamina,canDash);

        }
    }


    public void Hit(int _damage) 
    {
        _damage = _damage - armor > 0 ? _damage - armor : 0;
        currentHealth -= _damage;
        if (isPlayer)
        {
            anim.SetTrigger(AnimStrings.isHit);
        }

        Death();

        if (healthUI != null)
        {
            healthUI.SetHealthUI(maxHealth,currentHealth,isPlayer);

        }
    }
    public void Heal(int heal)
    {
        if (currentHealth < maxHealth)
        {
        currentHealth+= heal;
        }
        else
        {
            currentHealth = maxHealth;
        }
        healthUI.SetHealthUI(maxHealth, currentHealth, isPlayer);
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

    void Death()
    {
        if (currentHealth <= 0)
        {
            //TODO death animation
            DeathEventTrigger?.Invoke();
            gameObject.GetComponentInParent<Rigidbody2D>().gameObject.SetActive(false);
        }
    }

}
