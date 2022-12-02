using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{

    [SerializeField] List<Collider2D> triggerList;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggerList.Add(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        triggerList.Remove(collision);
    }

}
