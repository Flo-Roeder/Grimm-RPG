using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLoot : MonoBehaviour
{

    [SerializeField] ScriptableRandomSpawn lootTable;
    // Start is called before the first frame update
    void Awake()
    {
    }

    private void Start()
    {

    }

    public void DropLoot()
    {
        GameObject _tempParent = new ("spawn");
        _tempParent.transform.position=this.transform.position;
        lootTable.SpawnObject(_tempParent.transform);
    }

}
