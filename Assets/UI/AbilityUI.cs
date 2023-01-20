using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUI : MonoBehaviour
{

    [SerializeField] AbilityInventory abilityInventory;
    [SerializeField] Image primaryImage, secondaryImage, tercImage;

    private void Start()
    {
        UpdateAbilityUI();
    }
    public void UpdateAbilityUI()
    {
        primaryImage.sprite = abilityInventory.primary.GetComponent<SpriteRenderer>().sprite;
        secondaryImage.sprite=abilityInventory.secondary.GetComponent<SpriteRenderer>().sprite;
        tercImage.sprite=abilityInventory.terc.GetComponent<SpriteRenderer>().sprite;
    }


}
