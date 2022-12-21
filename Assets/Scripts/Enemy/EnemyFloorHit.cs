using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFloorHit : EnemyAttackBehave
{
    [SerializeField] Transform followTarget;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;

    private void Awake()
    {
        followTarget = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponentInParent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        if (stateDetection.enemyState == EnemyState.attack)
        {
            rb.velocity = Vector3.zero;
            anim.SetBool(AnimStrings.isAttacking,true);
        }
        else
        {
            anim.SetBool(AnimStrings.isAttacking, false);

        }
    }
}
