using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Chest : MonoBehaviour
{

    [SerializeField] enum Chesttype
    {
        normal,
        bombchest,
        keychest,
        damagechest
    }
    [SerializeField] Chesttype chesttype;
    [SerializeField] int value;

    [SerializeField] bool isOpen;
    [SerializeField] Sprite openSprite;
    SpriteRenderer spriteRenderer;

    [SerializeField] PlayerStats playerStats;
    [SerializeField] CollectableInventory collectableInventory;

    private SpawnLoot spawnLoot;

    // Start is called before the first frame update
    void Start()
    {
        spawnLoot= GetComponent<SpawnLoot>();
        spriteRenderer= GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!isOpen)
        {
            if (collision.CompareTag("PlayerHit"))
            {
                switch (chesttype)
                {
                    case Chesttype.normal:
                        OpenChest();
                        break;
                    case Chesttype.keychest:
                        if (collectableInventory.keys >= value)
                        {
                            OpenChest();
                            collectableInventory.keys -= value;
                            GameObject.FindGameObjectWithTag("CollectableUI").GetComponent<CollectablesUI>().CollectableUIUpdate();

                        }
                        break;
                    case Chesttype.damagechest:
                        if (playerStats.currentHealth > value)
                        {
                            OpenChest();
                            playerStats.currentHealth -= value;
                            GameObject.FindGameObjectWithTag("HealthUI").GetComponent<HealthUI>().SetHealthUI(playerStats.maxHealth, playerStats.currentHealth, true);
                        }
                        break;
                    default:
                        break;
                }
            }
            else if (collision.CompareTag("PlayerBomb")
                && chesttype==Chesttype.bombchest)
            {
                OpenChest();
            }
        }
    }

    private void OpenChest()
    {
        spriteRenderer.sprite = openSprite;
        isOpen = true;
        if (spawnLoot)
        {
            spawnLoot.DropLoot();
        }
    }
}
