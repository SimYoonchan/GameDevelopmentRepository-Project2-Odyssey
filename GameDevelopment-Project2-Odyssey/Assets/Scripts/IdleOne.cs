using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleOne : StateMachineBehaviour
{
    [SerializeField] float timer;
    [SerializeField] float minTime;
    [SerializeField] float maxTime;

    private int randomAnimation;

    //CachedReference:
    Vex vex;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(minTime, maxTime);

        randomAnimation = Random.Range(0, 2);

        vex = FindObjectOfType<Vex>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = timer - Time.deltaTime;

        if (timer <= 0 && randomAnimation == 0)
        {
            animator.SetTrigger("ShootOne");
        }

        else if (timer <= 0 && randomAnimation == 1)
        {
            animator.SetTrigger("ShootTwo");
        }

        else if (vex.GetVexHealth() <= vex.GetVexHalfHealth())
        {
            animator.SetTrigger("StageTwo");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (randomAnimation == 0) //This is for IdleOne.
        {
            animator.ResetTrigger("ShootOne");
        }

        else if (randomAnimation == 1) //This is for ShootOne.
        {
            animator.ResetTrigger("ShootTwo");
        }

        else if (vex.GetVexHealth() <= vex.GetVexHalfHealth())
        {
            animator.ResetTrigger("StageTwo");
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
