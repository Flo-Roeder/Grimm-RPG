using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName ="ScritableRandomSpawn")]
public class ScriptableRandomSpawn : ScriptableObject
{

    [SerializeField] GameObject[] objects;

    // Start is called before the first frame update
    void Awake()
    {
       // int rand = Random.Range(0, rooms.Length);
       // Instantiate(rooms[rand]);
    }

    public void SpawnObject(Transform transform)
    {
        int rand = Random.Range(0, objects.Length);
        Instantiate(objects[rand],transform);

    }
}
