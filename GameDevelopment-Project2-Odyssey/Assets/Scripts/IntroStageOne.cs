using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroStageOne : StateMachineBehaviour
{
    private int randomAnimation;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        randomAnimation = Random.Range(0, 3);
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (randomAnimation == 0) //This is for IdleOne.
        {
            animator.SetTrigger("IdleOne");
        }

        else if (randomAnimation == 1) //This is for ShootOne.
        {
            animator.SetTrigger("ShootOne");
        }

        else if (randomAnimation == 2) //This is for ShootTwo.
        {
            animator.SetTrigger("ShootTwo");
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //Thus, this is called once "IntroStageOne" animation is done.
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (randomAnimation == 0) //This is for IdleOne.
        {
            animator.ResetTrigger("IdleOne");
        }

        else if (randomAnimation == 1) //This is for ShootOne.
        {
            animator.ResetTrigger("ShootOne");
        }

        else if (randomAnimation == 2) //This is for ShootTwo.
        {
            animator.ResetTrigger("ShootTwo");
        }
    }

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
