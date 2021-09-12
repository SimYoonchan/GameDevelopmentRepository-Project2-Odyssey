using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroStageTwo : StateMachineBehaviour
{
    private int randomAnimation;

    Vex vex;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        randomAnimation = Random.Range(0, 3);

        vex = FindObjectOfType<Vex>();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (randomAnimation == 0 && vex.GetVexHealth() <= vex.GetVexHalfHealth()) //This is for IdleOne.
        {
            animator.SetTrigger("IdleTwo");
        }

        else if (randomAnimation == 1 && vex.GetVexHealth() <= vex.GetVexHalfHealth()) //This is for ShootOne.
        {
            animator.SetTrigger("ShootThree");
        }

        else if (randomAnimation == 2 && vex.GetVexHealth() <= vex.GetVexHalfHealth()) //This is for ShootTwo.
        {
            animator.SetTrigger("ShootFour");
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //Thus, this is called once "IntroStageOne" animation is done.
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (randomAnimation == 0 && vex.GetVexHealth() <= vex.GetVexHalfHealth()) //This is for IdleOne.
        {
            animator.ResetTrigger("IdleTwo");
        }

        else if (randomAnimation == 1 && vex.GetVexHealth() <= vex.GetVexHalfHealth()) //This is for ShootOne.
        {
            animator.ResetTrigger("ShootThree");
        }

        else if (randomAnimation == 2 && vex.GetVexHealth() <= vex.GetVexHalfHealth()) //This is for ShootTwo.
        {
            animator.ResetTrigger("ShootFour");
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
