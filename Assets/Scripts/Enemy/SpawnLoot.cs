using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLoot : MonoBehaviour
{

    [SerializeField] ScriptableRandomSpawn lootTable;
    [SerializeField] int lootAmount = 1;
    // Start is called before the first frame update
    void Awake()
    {
    }

    private void Start()
    {

    }

    public void DropLoot()
    {
        for (int i = 0; i < lootAmount; i++)
        {
            GameObject _tempParent = new ("spawn");
            _tempParent.transform.parent = this.transform.parent;
            _tempParent.transform.position=this.transform.position;
            lootTable.SpawnObject(_tempParent.transform);
        }
    }

}
