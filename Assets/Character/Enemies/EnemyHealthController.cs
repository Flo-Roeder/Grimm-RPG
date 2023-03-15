using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealthController : MonoBehaviour
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

    public delegate void DeathEvent();
    public static event DeathEvent DeathEventTrigger;

    SpawnLoot spawnLoot;

    Material material;

    private void Awake()
    {
        spawnLoot = GetComponent<SpawnLoot>();
        currentHealth = maxHealth;
        currentStamina= maxStamina;
        DeathEventTrigger = null;
    }

    private void Start()
    {
        material= GetComponent<SpriteRenderer>().material;

        if (healthUI!=null)
        {
            healthUI.SetHealthUI(maxHealth,currentHealth,isPlayer);
        }
    }

    private void Update()
    {
        currentStamina = currentStamina < maxStamina ? currentStamina + Time.deltaTime*10 : maxStamina;
    }


    public void Hit(int _damage) 
    {
        _damage = _damage - armor > 0 ? _damage - armor : 0;
        currentHealth -= _damage;

        material.SetFloat("_Fade", (float)currentHealth/(float)maxHealth+.25F);

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
            if (spawnLoot)
            {
                spawnLoot.DropLoot();
            }
            DeathEventTrigger?.Invoke();
            this.gameObject.SetActive(false);
        }
    }


}
