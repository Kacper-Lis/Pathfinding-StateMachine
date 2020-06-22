using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    public PlayerStateMachine pm;

    public State(PlayerStateMachine pm)
    {
        this.pm = pm;
    }

    public virtual void Enter() 
    {
        //Probably empty
    }

    public virtual void HandleInput() 
    {
        //Ability to pause the game and popup menu
        //Ability to click on unselected units to check their stats etc. updated UI
    }

    public virtual void PhysicsUpdate() 
    {
        //Probably empty
    }

    public virtual void LogicUpdate()
    { 
        //Probably empty
    }

    public virtual void Exit() 
    {
        //Probably empty
    }
}
