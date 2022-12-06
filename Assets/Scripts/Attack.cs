using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public float damage;

    [SerializeField] float staminaCost;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<HealthController>())
        {
            HealthController healthController= collision.GetComponent<HealthController>();
            healthController.Hit(damage);
        }
    }

    private void OnEnable()
    {
        if (this.gameObject.GetComponentInParent<HealthController>())
        {
            HealthController healthController = this.gameObject.GetComponentInParent<HealthController>();
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
    }
}
