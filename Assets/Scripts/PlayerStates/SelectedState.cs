using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedState : State
{
    private List<Tile> path;
    private List<Renderer[]> renderers;

    public Tile target;

    public SelectedState(PlayerStateMachine pm) : base(pm)
    {
    }

    public override void Enter()
    {
        base.Enter();
        pm.changePanel(pm.selectedPanel);

        renderers = new List<Renderer[]>();

        path = pm.pathFinding.getPossiblePath(pm.currentUnit, pm.currentUnit.moveSpeed);

        //Add sort of highlight effect instead of turning them green
        foreach (Tile t in path)
        {
            Renderer[] rs = t.GetComponentsInChildren<Renderer>();
            renderers.Add(rs);
            foreach (Renderer r in rs)
            {
                Material m = r.material;
                m.color = Color.green;
                r.material = m;
            }
        }
    }

    public override void HandleInput()
    {
        base.HandleInput();

        if (Input.GetButtonDown("Fire2"))
            move();
        pm.attackButton.onClick.AddListener(onClickChangeToAttack);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void LogicUpdate()
    {
        Debug.Log("Selected State");
        base.LogicUpdate();
    }

    public override void Exit()
    {
        base.Exit();

        for (int i = 0; i < renderers.Count; i++)
        {
            Renderer[] rs = renderers[i];
            foreach (Renderer r in rs)
            {
                Material m = r.material;
                m.color = Color.white;
                r.material = m;
            }
        }

        path = null;
    }

    private void move()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.transform.GetComponent<Tile>() != null)
            {
                Tile tile = hitInfo.transform.GetComponent<Tile>();
                if (path.Contains(tile))
                {
                    target = tile;
                    pm.changeState(pm.moveState);
                }
            }

        }
    }

    private void onClickChangeToAttack() 
    {
        pm.changeState(pm.attackState);
    }
}
