using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemiePrefabs;


    private void OnEnable()
    {
        int rand = Random.Range(0, enemiePrefabs.Length);
        if (enemiePrefabs[rand]!=null)
        {
            Instantiate(enemiePrefabs[rand],this.gameObject.transform);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
