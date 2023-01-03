using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealFountain : MonoBehaviour
{
    [SerializeField] int healAmount;
    [SerializeField] new GameObject light;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponentInChildren<PlayerHealthController>().Heal(healAmount);
            Destroy(this);
            if (light!=null)
            {
                light.SetActive(false);
            }
        }
    }
}

