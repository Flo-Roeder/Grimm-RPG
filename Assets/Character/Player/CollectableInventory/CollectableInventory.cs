using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="CollectableInventory")]
public class CollectableInventory : ScriptableObject
{
    //public Dictionary<string,int> inventoryList= new();

    public int coins;
    public int bombs;
    public int keys;

    public GameObject coinPrefab;
    public GameObject bombPrefab;
    public GameObject keyPrefab;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
