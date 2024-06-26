/// <remarks>
/// Author: Palin Wiseman
/// Date Created: March 15, 2024
/// Bugs: None known at this time.
/// </remarks>
// <summary>
/// This script is used to set a boolean value on the animator when entering or exiting a state or state machine.
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBoolBehaviour : StateMachineBehaviour
{
    public string boolName;
    public bool updateOnStateMachine, updateOnState;
    public bool valueOnEnter, valueOnExit;

    /// <summary>
    /// OnStateEnter is called on entering a state in the animator
    /// </summary>
    /// <param name="animator">The animator used</param>
    /// <param name="stateInfo">The state info</param>
    /// <param name="layerIndex">The index of the layer</param>
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (updateOnState)
        {
            animator.SetBool(boolName, valueOnEnter);
        }
    }
    /// <summary>
    /// OnStateExit is called on exiting a state in the animator
    /// </summary>
    /// <param name="animator">The animator used</param>
    /// <param name="stateInfo">The state info</param>
    /// <param name="layerIndex">The index of the layer</param>
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (updateOnState)
        {
            animator.SetBool(boolName, valueOnExit);
        }
    }


    /// <summary>
    /// OnStateMachineEnter is called when entering a state machine in the animator via its Entry Node
    /// </summary>
    /// <param name="animator">The animator used</param>
    /// <param name="stateInfo">The state info</param>
    /// <param name="layerIndex">The index of the layer</param>
    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        if (updateOnStateMachine)
        {
            animator.SetBool(boolName, valueOnEnter);
        }
    }
    
    /// <summary>
    /// OnStateMachineExit is called when exiting a state machine in the animator via its Exit Node
    /// </summary>
    /// <param name="animator">The animator used</param>
    /// <param name="stateInfo">The state info</param>
    /// <param name="layerIndex">The index of the layer</param>
    override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {
        if (updateOnStateMachine)
        {
            animator.SetBool(boolName, valueOnExit);
        }
    }
}
