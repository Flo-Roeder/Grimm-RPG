using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumpChase : EnemyAttackBehave
{
    [SerializeField] Transform followTarget;
    [SerializeField] float speed;
    [SerializeField] float chaseDelayMin;
    [SerializeField] float chaseDelayMax;
    [SerializeField] float chaseDuration;
    private float randChaseDelay;
    private Rigidbody2D rb;


    private void Awake()
    {
        followTarget = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponentInParent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        randChaseDelay = Random.Range(chaseDelayMin, chaseDelayMax);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (stateDetection.enemyState==EnemyState.attack)
        {
            Vector2 direction = (followTarget.position - transform.position).normalized;

            randChaseDelay -= Time.deltaTime;
            if (randChaseDelay <= 0)
            {
                //TODO lerp jump?
                rb.velocity = direction * speed;
                StartCoroutine(ChaseReset());
                randChaseDelay = Random.Range(chaseDelayMin, chaseDelayMax);
            }
        }
        
    }

    private IEnumerator ChaseReset()
    {
        yield return new WaitForSeconds(chaseDuration);
        rb.velocity = Vector2.zero;
    }
}
