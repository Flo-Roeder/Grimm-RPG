using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer= GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("PlayerHit") 
            && !isOpen)
        {
            switch (chesttype)
            {
                case Chesttype.normal:
                    spriteRenderer.sprite=openSprite;
                    isOpen=true;
                    break;
                case Chesttype.keychest:
                    if (collectableInventory.keys>=value)
                    {
                        spriteRenderer.sprite=openSprite;
                        isOpen=true;
                        collectableInventory.keys-=value;
                        GameObject.FindGameObjectWithTag("CollectableUI").GetComponent<CollectablesUI>().CollectableUIUpdate();

                    }
                    break;
                case Chesttype.damagechest:
                    if (playerStats.currentHealth>value)
                    {
                        spriteRenderer.sprite=openSprite;
                        isOpen=true;
                        playerStats.currentHealth -= value;
                        GameObject.FindGameObjectWithTag("HealthUI").GetComponent<HealthUI>().SetHealthUI(playerStats.maxHealth, playerStats.currentHealth, true);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
