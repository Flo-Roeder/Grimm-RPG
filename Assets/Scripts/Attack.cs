using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public float damage;

  /*  private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthController healthController= collision.GetComponent<HealthController>();
        if (healthController!=null)
        {
            healthController.Hit(damage);
        }
    }
  */

    private void OnTriggerEnter(Collider other)
    {
        HealthController healthController = other.GetComponent<HealthController>();
        if (healthController != null)
        {
            healthController.Hit(damage);
        }

    }
}
