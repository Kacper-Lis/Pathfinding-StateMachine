using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [HideInInspector] public int unitX;
    [HideInInspector] public int unitY;

    public float dmg = 1; //damage
    public float hp = 5;
    public float mp = 2; //move points

    public float moveSpeed = 2; //starting move points
    public float range = 3; //range of attacking if not melee

    public bool isMelee;
    public bool isAlly;

    public float initiative = 2;

    public void OnMouseUp()
    {
        Debug.Log("Unit " + unitX + "|" + unitY);
    }

}
