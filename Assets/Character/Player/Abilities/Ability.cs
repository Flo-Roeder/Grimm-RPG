using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ability : ScriptableObject
{
    [SerializeField] internal PlayerStats playerStats;
    [SerializeField] internal int staminaCost;
    [SerializeField] internal float activeTime;
    [SerializeField] internal float coolDown;
    public bool started;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public virtual void StartAbility(GameObject parent) { 

    }

    public virtual void StopAbility(GameObject parent) { }

    public virtual void RefreshAbility(GameObject parent) { }
}
