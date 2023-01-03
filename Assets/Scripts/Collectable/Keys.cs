using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Keys : MonoBehaviour
{
    [SerializeField] int keyValue;
    [SerializeField] int cost;
    [SerializeField] TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh.text = cost + " $";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CollectableInventory collectableInventory = collision.gameObject.GetComponent<PlayerController>().collectableInventory;
            if (collectableInventory.coins>=cost)
            {
            collectableInventory.keys += keyValue;
                collectableInventory.coins -= cost;
            Destroy(this.gameObject);
            GameObject.FindGameObjectWithTag("CollectableUI").GetComponent<CollectablesUI>().CollectableUIUpdate();
            }
        }
    }


}
