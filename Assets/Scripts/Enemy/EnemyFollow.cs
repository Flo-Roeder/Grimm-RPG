using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    [SerializeField] Transform followTarget;
    [SerializeField] float speed;

    private Rigidbody2D rb;

    private void Awake()
    {
        followTarget = GameObject.FindGameObjectWithTag("Player").transform;
        rb= GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (followTarget.position-transform.position).normalized;
        rb.velocity = direction*speed;
    }
}
