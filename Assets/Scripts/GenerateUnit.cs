using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateUnit : MonoBehaviour
{
    public Transform[] prefab;
    public string[] prefabSymbols;

    private Dictionary<string, Transform> prefabMap = new Dictionary<string, Transform>();

    private GenerateMap gridMap;
    public Transform[,] unitMap;

    public List<Unit> units;

    public void setup(List<string[]> data, int gridWidth, int gridHeight, GenerateMap map) 
    {
        for (int i = 0; i < prefab.Length; i++) 
        {
            prefabMap[prefabSymbols[i]] = prefab[i];
        }
        gridMap = map;
        unitMap = new Transform[gridHeight, gridWidth];
        spawnUnits(data);
    }

    public void spawnUnits(List<string[]> data) 
    {
        for (int y = 0; y < data.Count; y++) 
        {
            for (int x = 0; x < data[y].Length; x++) 
            {
                if (data[y][x].Equals("0"))
                {
                    unitMap[y, x] = null;
                }
                else 
                {
                    Transform unit = Instantiate(prefabMap[data[y][x]]) as Transform;
                    Unit u = unit.GetComponent<Unit>();
                    units.Add(u);
                    u.unitX = x;
                    u.unitY = y;
                    unitMap[y, x] = unit;
                    unit.position = gridMap.getTile(y, x).position + new Vector3(0, 0.65f);
                    unit.parent = this.transform;
                }
            }
        }
    }
}
