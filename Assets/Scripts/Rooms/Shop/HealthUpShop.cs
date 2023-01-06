using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class HealthUpShop : MonoBehaviour
{
    [SerializeField] int value;
    [SerializeField] int cost;
    [SerializeField] TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh.text = cost + " $";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CollectableInventory collectableInventory = collision.gameObject.GetComponent<PlayerController>().collectableInventory;
            PlayerHealthController playerHealthController = collision.gameObject.GetComponentInChildren<PlayerHealthController>();
            if (collectableInventory.coins >= cost)
            {
                playerHealthController.playerStats.maxHealth+=value;
                playerHealthController.SetHealthUI();
                collectableInventory.coins -= cost;
                Destroy(this.gameObject);
                GameObject.FindGameObjectWithTag("CollectableUI").GetComponent<CollectablesUI>().CollectableUIUpdate();
            }
        }
    }


}
