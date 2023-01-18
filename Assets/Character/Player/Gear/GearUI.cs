using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearUI : MonoBehaviour
{

    [SerializeField] Image helmetImage, armorImage, shoeImage, weaponImage, juweleryImage;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUIImages(GameObject gear)
    {
        Sprite sprite = gear.GetComponent<SpriteRenderer>().sprite;
        GearPickUp gearPick = gear.GetComponent<GearPickUp>();

        //TODO switch statement
        if (gearPick.gearType == GearType.helmet)
        {
            helmetImage.sprite = sprite;
        }
        else if (gearPick.gearType == GearType.armor)
        {
            armorImage.sprite = sprite;
        }
        else if (gearPick.gearType == GearType.weapon)
        {
            weaponImage.sprite = sprite;
        }
        else if (gearPick.gearType == GearType.shoes)
        {
            shoeImage.sprite = sprite;
        }
        else if (gearPick.gearType == GearType.juwelery)
        {
            juweleryImage.sprite = sprite;
        }
    }



}
