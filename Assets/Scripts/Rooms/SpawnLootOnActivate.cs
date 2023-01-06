using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLootOnActivate : SpawnLoot
{
    // Start is called before the first frame update
    void OnEnable()
    {
        DropLoot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
