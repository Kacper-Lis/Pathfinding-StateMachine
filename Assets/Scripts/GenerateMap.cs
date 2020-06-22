using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    //For tiles prefabs
    public Transform[] prefab;
    public string[] prefabSymbols;
    private Dictionary<string, Transform> prefabMap = new Dictionary<string, Transform>();

    public Tile[,] tiles;

    /*
     * Width first in file
     * Height second in file
     * Each array Height first
     */
    public int gridWidth;
    public int gridHeight;

    float hexWidth = 1.732f;
    float hexHeight = 2.0f;
    public float gap = 0.0f;

    private Vector3 startPos;

    public void setup(List<string[]> data) 
    {
        for (int i = 0; i < prefab.Length; i++) 
        {
            prefabMap[prefabSymbols[i]] = prefab[i];
        }

        try
        {
            gridWidth = int.Parse(data[0][0]);
            gridHeight = int.Parse(data[0][1]);
        }
        catch (Exception e) 
        {
            //Save the game and exit to avoid losing progress
        }
        
        tiles = new Tile[gridHeight, gridWidth];

        CalcStartPos();
        CreateGrid(data);
        generateGraph();
    }

    /*
     * No use for now/just for testing
     */
    void AddGap()
    {
        hexWidth += hexWidth * gap;
        hexHeight += hexHeight * gap;
    }

    /*
     * Graph for pathfinding
     */
    private void generateGraph() 
    {   
        for (int y = 0; y < gridHeight; y++) 
        {
            for (int x = 0; x < gridWidth; x++)
            {
                if (y % 2 != 0)
                {
                    if (x < gridWidth - 1)
                    {
                        //Right most
                        tiles[y, x].edges.Add(tiles[y, x + 1]);
                        //Right up
                        if (y > 0)
                            tiles[y, x].edges.Add(tiles[y - 1, x + 1]);
                        //Right down
                        if (y < gridHeight - 1)
                            tiles[y, x].edges.Add(tiles[y + 1, x + 1]);
                    }

                    //Left most
                    if (x > 0)
                        tiles[y, x].edges.Add(tiles[y, x - 1]);
                    //Left up
                    if (y > 0)
                        tiles[y, x].edges.Add(tiles[y - 1, x]);
                    //Left down
                    if (y < gridHeight - 1)
                        tiles[y, x].edges.Add(tiles[y + 1, x]);
                }
                else 
                {
                    if (y > 0) 
                    {
                        //Right up
                        tiles[y, x].edges.Add(tiles[y - 1, x]);
                        //Left up
                        if(x > 0)
                            tiles[y, x].edges.Add(tiles[y - 1, x - 1]);
                    }
                    if (y < gridHeight - 1) 
                    {
                        //Right down
                        tiles[y, x].edges.Add(tiles[y + 1, x]);
                        //Left down
                        if(x > 0)
                            tiles[y, x].edges.Add(tiles[y + 1, x - 1]);
                    }

                    //Right most
                    if(x < gridWidth - 1)
                        tiles[y, x].edges.Add(tiles[y, x + 1]);
                    //Left most
                    if(x > 0)
                        tiles[y, x].edges.Add(tiles[y, x - 1]);
                    
                }
            }
        }
    }

    private void CalcStartPos()
    {
        float offset = 0;
        if (gridHeight / 2 % 2 != 0)
            offset = hexWidth / 2;

        float x = -hexWidth * (gridWidth / 2) - offset;
        float z = hexHeight * 0.75f * (gridHeight / 2);

        startPos = new Vector3(x, 0, z);
    }
    

    private Vector3 CalcWorldPos(Vector2 gridPos)
    {
        float offset = 0;
        if (gridPos.y % 2 != 0)
            offset = hexWidth / 2;

        float x = startPos.x + gridPos.x * hexWidth + offset;
        float z = startPos.z - gridPos.y * hexHeight * 0.75f;

        return new Vector3(x, 0, z);
    }

    private void CreateGrid(List<string[]> data)
    {
        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                Transform hex = Instantiate(prefabMap[data[y+1][x]]) as Transform;
                Tile tile = hex.GetComponent<Tile>();
                tile.y = y;
                tile.x = x;
                tiles[y, x] = tile;
                hex.position = CalcWorldPos(new Vector2(x, y));
                hex.parent = this.transform;
                hex.name = "Hex " + y + "|" + x;
            }
        }
    }
    
    public Transform getTile(int y, int x) 
    {
        return tiles[y, x].GetComponent<Transform>();
    }

    public int getWidth() 
    {
        return gridWidth;
    }

    public int getHeight() 
    {
        return gridHeight;
    }
}
