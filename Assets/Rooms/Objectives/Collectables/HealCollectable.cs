using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class HealCollectable : Collectable
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CollectableInventory collectableInventory = collision.gameObject.GetComponent<PlayerController>().collectableInventory;
            collision.gameObject.GetComponentInChildren<PlayerHealthController>().Heal(value);
            Destroy(this.gameObject);
            GameObject.FindGameObjectWithTag("CollectableUI").GetComponent<CollectablesUI>().CollectableUIUpdate();
        }
    }


}
