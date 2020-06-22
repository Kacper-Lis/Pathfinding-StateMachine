using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : SelectedState
{
    public AttackState(PlayerStateMachine pm) : base(pm)
    {
    }

    public override void Enter() 
    {
        pm.changePanel(pm.attackPanel);
    }

    public override void HandleInput() { }

    public override void PhysicsUpdate() { }

    public override void LogicUpdate() 
    {
        Debug.Log("AttackState");
    }

    public override void Exit() { }
}
