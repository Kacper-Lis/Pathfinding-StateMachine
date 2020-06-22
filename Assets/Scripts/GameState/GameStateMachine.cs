using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    [HideInInspector] public MapBuilder map;

    [HideInInspector] public GameState currentState;

    [HideInInspector] public GameState deploy;
    [HideInInspector] public GameState checkTurn;
    [HideInInspector] public GameState end;
    private GameState load;

    public Transform canvas;

    public PlayerStateMachine pm;
    //public EnemyStateMachine em;

    public void Awake()
    {
        load = new Load(this);
        map = GetComponent<MapBuilder>();
        canvas = transform.Find("Canvas");
        Debug.Log("Test");
    }
    private void Start()
    {
        load.Enter();
    }

    public void ChangeState(GameState state) 
    {
        state.Exit();
        currentState = state;

        currentState.Enter();
    }

    private void Update()
    {
        currentState.HandleInput();

        currentState.LogicUpdate();

        if (pm != null) 
        {
            pm.StateLogicUpdate();
        }
    }

    private void FixedUpdate()
    {
        currentState.PhysicsUpdate();

        if (pm != null)
        {
            pm.StatePhysicsUpdate();
        }
    }
}
