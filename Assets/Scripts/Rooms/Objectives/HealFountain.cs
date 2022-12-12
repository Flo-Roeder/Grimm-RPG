using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealFountain : MonoBehaviour
{
    [SerializeField] float healRate;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponentInChildren<HealthController>().Heal(healRate);
        }
    }
}

