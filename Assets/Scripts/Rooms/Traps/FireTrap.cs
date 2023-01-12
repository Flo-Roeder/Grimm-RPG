using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [SerializeField] int ongoingDamage;
    [SerializeField] int initialDamage;
    [SerializeField] float restTime;
    private float restTimer;
    [SerializeField] float timeDelay;
    [SerializeField] float ticTime;
    private float ticTimer;
    [SerializeField] float attackTime;
    private float attackTimer;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim= GetComponent<Animator>();
        restTimer = restTime;
        ticTimer = ticTime;
        attackTimer= attackTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeDelay<=0)
        {
            PlayAnimation();
        }
        else
        {
            timeDelay-=Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerHealthController>())
        {
            PlayerHealthController healthController = collision.GetComponent<PlayerHealthController>();
            healthController.Hit(0, initialDamage);
        }

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerHealthController>())
        {
            if (ticTimer<=0)
            {
                PlayerHealthController healthController = collision.GetComponent<PlayerHealthController>();
                healthController.Hit(0,ongoingDamage);
                ticTimer = ticTime;
            }
            else
            {
                ticTimer-=Time.deltaTime;
            }
        }
    }

    private void PlayAnimation()
    {
        if (restTimer>0)
        {
            restTimer-=Time.deltaTime;
        }
        else if(attackTimer>0)
        {
            attackTimer-=Time.deltaTime;
            anim.SetBool(AnimStrings.isAttacking, true);
        }
        else
        {
            anim.SetBool(AnimStrings.isAttacking, false);
            restTimer = restTime;
            attackTimer = attackTime;
        }
    }
}
