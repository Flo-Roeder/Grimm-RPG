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
    [SerializeField]float pickUpDelay;
    [SerializeField]float pickUpDelayTimer;

    public GearType gearType;
    // [SerializeField] TextMeshProUGUI textMesh;

    private void Awake()
    {
        pickUpDelayTimer = pickUpDelay;
        collider.enabled = false;
        //canPickUp= false;
    }

    // Update is called once per frame
    void Update()
    {
        pickUpDelayTimer -= Time.deltaTime;
        if (pickUpDelayTimer<0)
        {
            collider.enabled= true;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();
            GearInventory gearInventory = playerController.gearInventory;

            switch(gearType)
            {
                case GearType.weapon:
                    gearInventory.PicUpNewWeapon(preFab);
                    break;
                case GearType.armor:
                    gearInventory.PicUpNewArmor(preFab);
                    break;
                case GearType.helmet:
                    gearInventory.PicUpNewHelmet(preFab);
                    break;
                case GearType.shoes:
                    gearInventory.PicUpNewShoes(preFab);
                    break;
                case GearType.juwelery:
                    gearInventory.PicUpNewJewelery(preFab);
                    break;
                default:
                    break;
            }
            playerController.SetStats();
            GameObject.FindGameObjectWithTag("GearUI").GetComponent<GearUI>().UpdateUIImages(preFab);
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }

  
}
