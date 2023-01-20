using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum CollectableType
{
    bomb,
    key,
    heal,
    healthUp,
    staminaUp

}

public class ShopPickUp : MonoBehaviour
{
    [SerializeField] int value;
    [SerializeField] int cost;
    [SerializeField] TextMeshProUGUI textMesh;

    [SerializeField] CollectableType collectableType;

    private void Start()
    {
        textMesh.text = cost + " $";
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInteract playerInteract = collision.GetComponent<PlayerInteract>();
            playerInteract.CanInteract(true);
            if (playerInteract.isInteracting)
            {


                CollectableInventory collectableInventory = collision.gameObject.GetComponent<PlayerController>().collectableInventory;
                PlayerHealthController playerHealthController = collision.gameObject.GetComponentInChildren<PlayerHealthController>();

                if (collectableInventory.coins >= cost)
                {
                    switch (collectableType)
                    {
                        case CollectableType.bomb:
                            collectableInventory.bombs += value;
                            collectableInventory.coins -= cost;
                            break;
                        case CollectableType.key:
                            collectableInventory.keys += value;
                            collectableInventory.coins -= cost;
                            break;
                        case CollectableType.heal:
                            playerHealthController.Heal(value);
                            collectableInventory.coins -= cost;
                            break;
                        case CollectableType.healthUp:
                            playerHealthController.playerStats.maxHealth += value;
                            playerHealthController.SetHealthUI();
                            collectableInventory.coins -= cost;
                            break;
                        case CollectableType.staminaUp:
                            playerHealthController.playerStats.maxStamina += value;
                            playerHealthController.SetHealthUI();
                            collectableInventory.coins -= cost;
                            break;
                    }
                    Destroy(this.gameObject);
                    GameObject.FindGameObjectWithTag("CollectableUI").GetComponent<CollectablesUI>().CollectableUIUpdate();
                    playerInteract.isInteracting = false;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInteract playerInteract = collision.GetComponent<PlayerInteract>();
            playerInteract.CanInteract(false);
        }
    }

}
