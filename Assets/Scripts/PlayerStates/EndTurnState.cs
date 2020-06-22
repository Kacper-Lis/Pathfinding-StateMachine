using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnState : SelectedState
{
    public EndTurnState(PlayerStateMachine pm) : base(pm)
    {
    }

    public override void Enter() 
    {
        pm.currentUnit = null;
    }

    public override void HandleInput() { }

    public override void PhysicsUpdate() { }

    public override void LogicUpdate() 
    {
        Debug.Log("EndTurn");
        if (pm.currentUnit != null && pm.currentUnit.isAlly) 
        {
            pm.changeState(pm.selectedState);
        }
    }

    public override void Exit() { }
}
