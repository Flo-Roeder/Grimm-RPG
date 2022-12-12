using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRoom : MonoBehaviour
{
    [SerializeField] RoomHandler roomHandler;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            roomHandler.roomStarted = true;
        }
    }

}
