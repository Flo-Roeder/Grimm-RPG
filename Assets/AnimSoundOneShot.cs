using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimSoundOneShot : StateMachineBehaviour
{
    public AudioClip[] audioClip;
    public float volume = 1f;

    public bool onEnter;
    public bool playDelayed;
    public float delayTime;
    private float delayTimer;

    private bool hasPlayed;

    private int rand;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rand= Random.Range(0, audioClip.Length);




        if (onEnter)
        {
            AudioSource.PlayClipAtPoint(audioClip[rand], animator.gameObject.transform.position, volume);
        }
        delayTimer = delayTime;
        hasPlayed = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playDelayed
            &&!hasPlayed)
        {
            delayTimer-= Time.deltaTime;

            if (delayTimer < 0)
            {
                AudioSource.PlayClipAtPoint(audioClip[rand], animator.gameObject.transform.position, volume);
                hasPlayed= true;
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
