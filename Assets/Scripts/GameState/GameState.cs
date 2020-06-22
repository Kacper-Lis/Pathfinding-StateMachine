using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState
{
    public GameStateMachine gm;

    public GameState(GameStateMachine gm) 
    {
        this.gm = gm;
    }

    public virtual void Enter() { }

    public virtual void HandleInput() { }

    public virtual void PhysicsUpdate() { }

    public virtual void LogicUpdate() { }

    public virtual void Exit() { }
}
