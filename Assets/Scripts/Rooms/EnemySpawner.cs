using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemiePrefabs;
    int rand;


    private void Start()
    {
    }

    private void OnEnable()
    {
        if (enemiePrefabs.Length>0)
        {
            rand = Random.Range(0, enemiePrefabs.Length);
            if (enemiePrefabs[rand]==null)
            {
                Destroy(this.gameObject);
            }
            else if(enemiePrefabs!=null)
            {
                Instantiate(enemiePrefabs[rand],this.gameObject.transform);
            }
        }
    }
}
