using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    /*
     * Movement to be improved by replacing dijkstra algorithm by A* search
     */
    public MapBuilder map;

	[HideInInspector] public MouseManager m;

	private Unit selectedUnit;


	private void Start()
	{
		m = GameObject.FindObjectOfType<MouseManager>();
	}



}
