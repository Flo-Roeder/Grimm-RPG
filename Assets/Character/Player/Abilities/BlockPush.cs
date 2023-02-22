using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPush : MonoBehaviour
{

    public float knockbackAmount;
    public float knockbackTime;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //EnemyAttackBehave enemyBehave = collision.GetComponent<EnemyAttackBehave>();
            //enemyBehave.stateDetection.enemyState = EnemyState.hit;
            EnemyState enemyState = collision.GetComponent<DetectPlayerDistance>().enemyState = EnemyState.hit;
            Rigidbody2D enemyRb = collision.GetComponent<Rigidbody2D>();
            enemyRb.velocity = (collision.transform.position- this.transform.position).normalized * knockbackAmount;
            StartCoroutine(HitCo(enemyRb));
            enemyState = EnemyState.idle;
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
            collision.GetComponent<DetectPlayerDistance>().enemyState = EnemyState.idle;

        }
    }
}
