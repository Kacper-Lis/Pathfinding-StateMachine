using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerStateMachine
{
    //public Canvas canvas;
    public Transform currentPanel;
    private Transform canvas;
    /*
     * Selected state panel
     */
    public Transform selectedPanel;
    public Button attackButton;
    public Button waitButton;
    public Text hpText;
    public Text mpText;
    public Text dmgText;

    /*
     * Attack state panel
     */
    public Transform attackPanel;
    public Text attackText;

    private State currentState;
    [HideInInspector] public Unit currentUnit;
    [HideInInspector] public GenerateMap map;

    /*
     * All the states
     */
    public State moveState;
    public State attackState;
    public State waitState;
    public State selectedState;
    public State endTurn;

    /*
     * Functional scripts
     */
    public Pathfinding pathFinding;

    public PlayerStateMachine(GenerateMap m, Transform canvas) 
    {
        this.map = m;
        this.canvas = canvas;
        moveState = new MoveState(this);
        attackState = new AttackState(this);
        waitState = new WaitState(this);
        selectedState = new SelectedState(this);
        endTurn = new EndTurnState(this);
        pathFinding = new Pathfinding(map.tiles);
    }

    //Should be in deploy for now temp in checkturn
    public void setup() 
    {
        currentState = endTurn;

        selectedPanel = canvas.Find("SelectedPanel");
        attackButton = selectedPanel.Find("Attack").GetComponent<Button>();
        waitButton = selectedPanel.Find("Wait").GetComponent<Button>();
        hpText = selectedPanel.Find("HP").GetComponent<Text>();
        mpText = selectedPanel.Find("MP").GetComponent<Text>();
        dmgText = selectedPanel.Find("DMG").GetComponent<Text>();

        attackPanel = canvas.Find("AttackPanel");
        attackText = attackPanel.Find("AttackText").GetComponent<Text>();
    }

    public void changePanel(Transform panel) 
    {
        if(currentPanel != null)
            currentPanel.gameObject.SetActive(false);

        currentPanel = panel;
        currentPanel.gameObject.SetActive(true);
    }

    public void changeState(State state) 
    {
        currentState.Exit();
        currentState = state;

        currentState.Enter();
    }

    public void CanvasTextUpdate() 
    {
        if(currentUnit != null)
        {
            hpText.text = "HP: " + currentUnit.hp;
            mpText.text = "MP: " + currentUnit.moveSpeed;
            dmgText.text = "DMG: " + currentUnit.dmg;

            attackText.text = "Attack: " + currentUnit.dmg;
        }
        
    }

    public void StateLogicUpdate() 
    {
        currentState.HandleInput();
        currentState.LogicUpdate();

        CanvasTextUpdate();
    }

    public void StatePhysicsUpdate() 
    {
        currentState.PhysicsUpdate();
    }
}
