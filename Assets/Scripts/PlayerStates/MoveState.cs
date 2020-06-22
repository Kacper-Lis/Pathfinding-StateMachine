using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    public MoveState(PlayerStateMachine pm) : base(pm)
    {
    }

    public override void Enter() 
    {
        Debug.Log("Moving");
    }

    public override void HandleInput() 
    {
        
    }

    public override void PhysicsUpdate() 
    { 

    }

    public override void LogicUpdate() 
    {
        Debug.Log("MoveState");
    }

    public override void Exit() 
    {
        base.Exit();
    }
}
