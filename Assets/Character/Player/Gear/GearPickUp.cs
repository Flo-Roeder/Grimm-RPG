using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum GearType
{
    helmet,
    armor,
    weapon,
    shoes,
    juwelery
}



public class GearPickUp : MonoBehaviour
{

    public int maxHealth, armor, maxStamina, staminaReg, moveSpeed, dashSpeed,
                dashStamina, attackDamage, critChance, attackStamina, knockbackAmount;
    public float critMulti;
    [SerializeField] GameObject preFab;
    [SerializeField] new Collider2D collider;

    public GearType gearType;
    // [SerializeField] TextMeshProUGUI textMesh;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInteract playerInteract = collision.GetComponent<PlayerInteract>();
            playerInteract.CanInteract(true);

            if (playerInteract.isInteracting) 
            {
                PlayerController playerController = collision.GetComponent<PlayerController>();
                GearInventory gearInventory = playerController.gearInventory;

                switch (gearType)
                {
                    case GearType.weapon:
                        gearInventory.PickUpNewWeapon(preFab,transform.parent);
                        break;
                    case GearType.armor:
                        gearInventory.PickUpNewArmor(preFab, transform.parent);
                        break;
                    case GearType.helmet:
                        gearInventory.PickUpNewHelmet(preFab, transform.parent);
                        break;
                    case GearType.shoes:
                        gearInventory.PickUpNewShoes(preFab, transform.parent);
                        break;
                    case GearType.juwelery:
                        gearInventory.PickUpNewJewelery(preFab, transform.parent);
                        break;
                    default:
                        break;
                }
                playerController.SetStats();
                GameObject.FindGameObjectWithTag("GearUI").GetComponent<GearUI>().UpdateUIImages(preFab);
                //Destroy(this.gameObject);
                this.gameObject.SetActive(false);
                playerInteract.isInteracting = false;
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
