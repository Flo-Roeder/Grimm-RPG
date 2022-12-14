using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleAround : EnemyAttackBehave
{

    [SerializeField] float minWalkTime, maxWalkTime;
    [SerializeField]float randWalkTime;
    [SerializeField] float minDelay, maxDelay;
    [SerializeField]float randDelay;
    [SerializeField] float minForce, maxForce;
    [SerializeField] float randForce;

    [SerializeField]private Vector2 randDirection;
    [SerializeField] Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponentInParent<Rigidbody2D>();
        randWalkTime = Random.Range(minWalkTime, maxWalkTime);
        CalculateRandomness();
    }

    // Update is called once per frame
    void Update()
    {
        if (stateDetection.enemyState==EnemyState.idle)
        {
            if (randDelay <= 0
            && randWalkTime <= 0)
            {
                CalculateRandomness();
            }
            else if (randWalkTime <= 0)
            {
                randDelay -= Time.deltaTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                randWalkTime -= Time.deltaTime;
            }
        }
        
    }

    private void FixedUpdate()
    {
        if (randDelay<=0)
        {
            MakeMove();
        }
    }

    private void MakeMove()
    {
        rb.velocity = randDirection * randForce;
    }

    private void CalculateRandomness()
    {
        randDelay = Random.Range(minDelay, maxDelay);
        randWalkTime= Random.Range(minWalkTime,maxWalkTime);
        randForce = Random.Range(minForce,maxForce);
        randDirection = new Vector2(Random.Range(-1f,1f),Random.Range(-1f,1f));
    }


}
