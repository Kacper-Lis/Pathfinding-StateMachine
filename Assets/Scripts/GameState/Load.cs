using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : GameState
{
    public Load(GameStateMachine gm) : base(gm)
    {
    }

    public override void Enter()
    {
        //Add loading screen or something
        base.Enter();
        gm.map.setup();
        gm.deploy = new Deploy(gm);
        gm.checkTurn = new CheckTurn(gm);
        gm.pm = new PlayerStateMachine(gm.map.grid, gm.canvas);
        //gm.em = new EnemyStateMachine();
        gm.ChangeState(gm.checkTurn);
    }

    public override void Exit()
    {
        //make the loading screen disappear and transition to deployment
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
