using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

[CreateAssetMenu(menuName ="ScritableRooms")]
public class ScriptableRoom : ScriptableObject
{

    [SerializeField] GameObject[] rooms;

    // Start is called before the first frame update
    void Awake()
    {
       // int rand = Random.Range(0, rooms.Length);
       // Instantiate(rooms[rand]);
    }

    public void GenerateRoom(Transform transform)
    {
        int rand = Random.Range(0, rooms.Length);
        Instantiate(rooms[rand],transform);

    }
}
