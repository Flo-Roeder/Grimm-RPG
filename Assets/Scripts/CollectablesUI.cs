using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CollectablesUI : MonoBehaviour
{

    [SerializeField] CollectableInventory collectableInventory;

    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] TextMeshProUGUI bombText;
    [SerializeField] TextMeshProUGUI keyText;

    // Start is called before the first frame update
    void Start()
    {
      //  collectableInventory.inventoryList.Clear();
      //  collectableInventory.inventoryList.Add("coins",0);
      //  collectableInventory.inventoryList.Add("bombs", 1);
      //  collectableInventory.inventoryList.Add("keys", 2);
        CollectableUIUpdate();
    }

    public void CollectableUIUpdate()
    {
        coinText.text = collectableInventory.coins.ToString();
        bombText.text = collectableInventory.bombs.ToString();
        keyText.text = collectableInventory.keys.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
