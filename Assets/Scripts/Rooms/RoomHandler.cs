using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomHandler : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    [SerializeField] GameObject finishLayer;

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length==0 )
        {
            finishLayer.SetActive(false);
        }
    }
}
