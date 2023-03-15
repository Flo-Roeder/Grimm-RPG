using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPush : MonoBehaviour
{

    public float knockbackAmount;
    public float knockbackTime;
    [SerializeField] private int damage;
    private float tickTimer = 0f;
    [SerializeField] private float tickTime;
    [SerializeField]private bool canTick;
    List<EnemyHealthController> _enemyHealths;

    private void Start()
    {
        _enemyHealths= new List<EnemyHealthController>();
        tickTimer = tickTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy"))
        {
            return;
        }
        //EnemyAttackBehave enemyBehave = collision.GetComponent<EnemyAttackBehave>();
        //enemyBehave.stateDetection.enemyState = EnemyState.hit;
        _enemyHealths.Add(collision.GetComponent<EnemyHealthController>());
        EnemyState enemyState = collision.GetComponent<DetectPlayerDistance>().enemyState = EnemyState.hit;
        Rigidbody2D enemyRb = collision.GetComponent<Rigidbody2D>();
        //some weirdness hiting sometimes double/triplle
        collision.GetComponent<EnemyHealthController>().Hit(damage);
        enemyRb.velocity = (collision.transform.position - this.transform.position).normalized * knockbackAmount;
        StartCoroutine(HitCo(enemyRb));
        enemyState = EnemyState.idle;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy"))
        {
            return;
        }
        if (!canTick)
        {
            return;
        }
        else if (tickTimer > 0)
        {
            tickTimer -= Time.deltaTime;
            return;
        }
        else
        {
            foreach (EnemyHealthController item in _enemyHealths)
            {
                item.Hit(damage);
            }
                tickTimer = tickTime;
        }

    }

    private IEnumerator HitCo(Rigidbody2D enemyRb)
    {
        yield return new WaitForSeconds(knockbackTime);
        enemyRb.velocity = Vector2.zero;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            _enemyHealths.Remove(collision.GetComponent<EnemyHealthController>());

            collision.GetComponent<DetectPlayerDistance>().enemyState = EnemyState.idle;

        }
    }
}
