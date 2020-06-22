using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTurn : GameState
{
    public List<Unit> unitList;

    public Unit currentUnit;
    /*
     * Might need to store the number of enemy and ally units to determine the end of the game
     */
    public CheckTurn(GameStateMachine gm) : base(gm)
    {
    }

    public override void Enter()
    {
        base.Enter();
        unitList = gm.map.units.units;
        gm.pm.currentUnit = unitList[2];
        gm.pm.setup();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
