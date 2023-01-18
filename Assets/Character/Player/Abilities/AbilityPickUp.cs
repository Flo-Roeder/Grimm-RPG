using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AbilityType
{
    primary,
    secondary,
    terc
}

public class AbilityPickUp : MonoBehaviour
{


    [SerializeField] AbilityType abilityType;

    [SerializeField] GameObject preFab;
    [SerializeField] new Collider2D collider;
    public Ability ability;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInteract playerInteract = collision.GetComponent<PlayerInteract>();
            playerInteract.CanInteract(true);

            if (playerInteract.isInteracting)
            {
                PlayerController playerController = collision.GetComponent<PlayerController>();
                AbilityInventory abilityInventory = playerController.abilityInventory;

                switch (abilityType)
                {
                    case AbilityType.primary:
                        abilityInventory.PickUpNewPrimary(preFab, transform.parent);
                        break;
                    case AbilityType.secondary:
                        abilityInventory.PickUpNewSecondary(preFab, transform.parent);
                        break;
                    case AbilityType.terc:
                        abilityInventory.PickUpNewTerc(preFab, transform.parent);
                        break;
                    default:
                        break;
                }
                //playerController.SetStats();
                //GameObject.FindGameObjectWithTag("GearUI").GetComponent<GearUI>().UpdateUIImages(preFab);
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

