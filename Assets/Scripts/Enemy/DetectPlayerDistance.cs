using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    chase,
    attack
}
public class DetectPlayerDistance : EnemyAttackBehave
{
    public EnemyState enemyState;

    private GameObject player;
    private float distance;
    [SerializeField] float chaseRaduis;
    [SerializeField] float attackRadius;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void Update()
    { 
        distance = Vector2.SqrMagnitude(player.transform.position- transform.position);
        
        if (distance<attackRadius)
        {
            enemyState = EnemyState.attack;
        }
        else if (distance<chaseRaduis)
        {
            enemyState = EnemyState.chase;
        }
        else
        {
            enemyState = EnemyState.idle;
        }
    }


}
