using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerGear : MonoBehaviour
{

    [SerializeField] GearInventory gearInventory;

    // Start is called before the first frame update
    void Start()
    {
        gearInventory.ResetGear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
