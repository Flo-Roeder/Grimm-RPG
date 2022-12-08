using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextRoom : MonoBehaviour
{
    [SerializeField] ScriptableRoom randomroomTemplate;
    [SerializeField] GameObject room;
    [SerializeField] Transform roomSpawnPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("spawnRoom");
            //  Instantiate(randomroomTemplate,roomSpawnPoint,true);
            randomroomTemplate.GenerateRoom(roomSpawnPoint);
        }
    }
}
