using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimBoolBehave : StateMachineBehaviour
{

    public bool enterState;
    public bool exitState;
    public string boolName;
    public bool setEnter;
    public bool setExit;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (enterState)
        {
            animator.SetBool(boolName, setEnter);
        }
    }



    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (exitState)
        {
            animator.SetBool(boolName, setExit);
        }
    }


}
