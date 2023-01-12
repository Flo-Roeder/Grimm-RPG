using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ActivatableObject : MonoBehaviour
{

    [SerializeField] enum Opentype
    {
        normal,
        bomb,
        key,
        damage
    }
    [SerializeField] Opentype opentype;

    [SerializeField] bool isOpen;
    [SerializeField] Sprite openSprite;
    SpriteRenderer spriteRenderer;


    [Header("Optional for beneath")]
    [SerializeField] int value;

    [Header("Optional for Damage Object")]
    [SerializeField] PlayerStats playerStats;

    [Header("Optional for Key Object")]
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
                switch (opentype)
                {
                    case Opentype.normal:
                        OpenChest();
                        break;
                    case Opentype.key:
                        if (collectableInventory.keys >= value)
                        {
                            OpenChest();
                            collectableInventory.keys -= value;
                            GameObject.FindGameObjectWithTag("CollectableUI").GetComponent<CollectablesUI>().CollectableUIUpdate();

                        }
                        break;
                    case Opentype.damage:
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
                && opentype ==Opentype.bomb)
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