using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BombCollectable : Collectable
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().collectableInventory.bombs += value;
            Destroy(this.gameObject);
            GameObject.FindGameObjectWithTag("CollectableUI").GetComponent<CollectablesUI>().CollectableUIUpdate();
        }
    }


}
