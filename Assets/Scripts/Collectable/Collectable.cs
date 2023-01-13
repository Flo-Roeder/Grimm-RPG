using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] internal int value;
    [SerializeField] float delayTime;
    float delayTimer;
    [SerializeField] Collider2D trigger;
    // Start is called before the first frame update
    void Awake()
    {
        trigger.enabled = false;
        delayTimer = delayTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (delayTimer<=0)
        {
            trigger.enabled = true;
        }
        else
        {
            delayTimer-=Time.deltaTime;
        }
    }
}
