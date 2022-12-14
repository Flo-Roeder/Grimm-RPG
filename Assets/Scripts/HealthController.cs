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

    [SerializeField] bool isPlayer;
    [SerializeField] HealthUI healthUI;
    Animator anim;

    private void Awake()
    {
        currentHealth = maxHealth;
        currentStamina= maxStamina;
        anim= GetComponentInParent<Animator>();
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


    public void Hit(float damage) 
    {
        currentHealth -= damage;
        if (isPlayer)
        {
            anim.SetTrigger(AnimStrings.isHit);
        }


        if (currentHealth<=0)
        {
            //TODO death animation
            gameObject.GetComponentInParent<Rigidbody2D>().gameObject.SetActive(false);
        }

        if (healthUI != null)
        {
            healthUI.SetHealthUI(maxHealth,currentHealth,isPlayer);

        }
    }
    public void Heal(float heal)
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

}
