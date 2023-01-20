using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerGear : MonoBehaviour
{

    [SerializeField] GearInventory gearInventory;
    [SerializeField] AbilityInventory abilityInventory;

    // Start is called before the first frame update
    void Awake()
    {
        gearInventory.ResetGear();
        abilityInventory.ResetAbility();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
