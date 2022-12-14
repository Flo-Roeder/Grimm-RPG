using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [Tooltip("for higher chance input the object multiple times")]
    public GameObject[] prefabsToRandomize;
    int rand;


    private void Start()
    {
    }

    private void OnEnable()
    {
        if (prefabsToRandomize.Length>0)
        {
            rand = Random.Range(0, prefabsToRandomize.Length);
            if (prefabsToRandomize[rand]==null)
            {
                Destroy(this.gameObject);
            }
            else if(prefabsToRandomize!=null)
            {
                Instantiate(prefabsToRandomize[rand],this.gameObject.transform);
            }
        }
    }
}
