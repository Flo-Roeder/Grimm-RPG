using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Color idleColor;
    public Color chaseColor;
    public Color attackColor;
    [SerializeField] Image healthFill;

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
            healthFill.color = attackColor;
        }
        else if (distance<chaseRaduis)
        {
            enemyState = EnemyState.chase;
            healthFill.color = chaseColor;

        }
        else
        {
            enemyState = EnemyState.idle;
            healthFill.color = idleColor;

        }
    }


}
