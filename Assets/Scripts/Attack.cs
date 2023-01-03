using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public int damage;
    [SerializeField] int critChancePercentage;
    [SerializeField] float critMultiplier;

    [SerializeField] float knockbackAmount;
    float knockbackForce;
    [SerializeField] float knockbackTime;
    public float knockbackTimer;

    private Vector2 knockbackDirection;
    private Rigidbody2D rb;
    [SerializeField] int staminaCost;

    [SerializeField] bool isPlayer;
    [SerializeField] PlayerStats playerStats;

    private void Awake()
    {
        SetStats();
    }

    private void SetStats()
    {
        if (isPlayer)
        {
            damage = playerStats.attackDamage;
            critChancePercentage = playerStats.critChancePercentage;
            critMultiplier = playerStats.critMultiplier;
            knockbackAmount = playerStats.knockbackAmount;
            knockbackTime = playerStats.knockbackTime;
            staminaCost = (int)playerStats.attackStaminaCost;
        }
    }

    private void FixedUpdate()
    {
        if (rb != null)
        {
            if (knockbackTimer > 0)
            {
                knockbackTimer -= Time.deltaTime;
                knockbackForce= Mathf.Lerp(0,knockbackForce,knockbackTimer*100);
                rb.AddForce(knockbackDirection * knockbackForce);
            }
            else
            {
            rb.AddForce(Vector2.zero);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyHealthController>())
        {
            EnemyHealthController healthController= collision.GetComponent<EnemyHealthController>();
            rb=healthController.GetComponentInParent<Rigidbody2D>();
            knockbackDirection = (rb.gameObject.transform.position-transform.position).normalized;
            knockbackTimer = knockbackTime;
            knockbackForce = knockbackAmount;
            healthController.Hit(CalculateDamage());
        }
        else if (collision.GetComponent<PlayerHealthController>())
        {
            PlayerHealthController healthController = collision.GetComponent<PlayerHealthController>();
            rb = healthController.GetComponentInParent<Rigidbody2D>();
            knockbackDirection = (rb.gameObject.transform.position - transform.position).normalized;
            knockbackTimer = knockbackTime;
            knockbackForce = knockbackAmount;
            healthController.Hit(CalculateDamage());
        }
    }

    private void OnEnable()
    {
        if (this.gameObject.GetComponentInParent<EnemyHealthController>())
        {
            EnemyHealthController healthController = this.gameObject.GetComponentInParent<EnemyHealthController>();
            if (healthController.currentStamina>staminaCost)
            {
            healthController.TakeStamina(staminaCost);
            }
            else
            {
                //TODO stamina stagger
                //stamina regen stop for short period
                //no further attacks
                //reduced movespeed?
            }
        }
        else if (this.gameObject.GetComponentInParent<PlayerHealthController>())
        {
            PlayerHealthController healthController = this.gameObject.GetComponentInParent<PlayerHealthController>();
            if (healthController.playerStats.currentStamina > staminaCost)
            {
                healthController.TakeStamina(staminaCost);
            }
            else
            {
                //TODO stamina stagger
                //stamina regen stop for short period
                //no further attacks
                //reduced movespeed?
            }
        }
    }

    private int CalculateDamage()
    {
        int _checkCrit = Random.Range(0, 101);
        return (int)(_checkCrit <= critChancePercentage ? damage * critMultiplier : damage);
    }
}
