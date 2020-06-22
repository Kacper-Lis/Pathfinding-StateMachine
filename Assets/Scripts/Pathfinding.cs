using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{
    private Tile[,] tiles;

    public Pathfinding(Tile[,] tiles) 
    {
        this.tiles = tiles;
    }

    public List<Tile> getPossiblePath(Unit unit, float range)
    {
        List<Tile> openList = new List<Tile>();
        List<Tile> closedList = new List<Tile>();
        Dictionary<Tile, float> movementPoints = new Dictionary<Tile, float>();

        openList.Clear();
        closedList.Clear();

        Tile source = tiles[unit.unitY, unit.unitX];

        movementPoints[source] = range;

        float parentPoints = movementPoints[source];
        closedList.Add(source);
        foreach (Tile tile in source.edges)
        {
            if (closedList.Contains(tile) || openList.Contains(tile))
                continue;
            float points = parentPoints - CostToEnterTile(tile.y, tile.x);
            if (points < 0)
            {
                // this tile is outside of the reachable area
                continue;
            }
            openList.Add(tile);
            movementPoints[tile] = points;
        }

        while (openList.Count > 0)
        {
            openList.Sort((a, b) => movementPoints[a].CompareTo(movementPoints[b]));
            Tile tile = openList[openList.Count - 1];
            openList.RemoveAt(openList.Count - 1);

            parentPoints = movementPoints[tile];
            closedList.Add(tile);
            foreach (Tile t in tile.edges)
            {
                if (closedList.Contains(t) || openList.Contains(t))
                    continue;
                float points = parentPoints - CostToEnterTile(t.y, t.x);
                if (points < 0)
                {
                    // this tile is outside of the reachable area
                    continue;
                }
                openList.Add(t);
                movementPoints[t] = points;
            }
        }

        return closedList;
    }

    public int CostToEnterTile(int targetY, int targetX)
    {
        Tile t = tiles[targetY, targetX].GetComponent<Tile>();

        if (t.isWalkable == false)
            return int.MaxValue;

        return t.movementCost;
    }

    //First version might be useful later for now doesn't work properly 
    /*
    public void getPossiblePath(Unit unit)
    {
        List<Tile> visited = new List<Tile>();
        List<Tile> path = new List<Tile>();

        Dictionary<Tile, int> dist = new Dictionary<Tile, int>();

        Tile source = tiles[unit.unitY, unit.unitX];

        dist[source] = 0;

        Queue<Tile> toCheck = new Queue<Tile>();

        foreach (Tile v in tiles)
        {
            if (v != source)
            {
                dist[v] = int.MaxValue;
            }
        }

        foreach (Tile v in source.edges)
        {
            toCheck.Enqueue(v);
            visited.Add(v);
            dist[v] = CostToEnterTile(v.y, v.x);
        }

        while (toCheck.Count > 0)
        {
            Tile u = toCheck.Dequeue();

            foreach (Tile v in u.edges)
            {
                if (visited.Contains(v))
                    continue;

                visited.Add(v);
                dist[v] = dist[u] + CostToEnterTile(v.y, v.x);

                if (dist[v] <= unit.moveSpeed)
                {
                    foreach (Tile n in v.edges)
                    {
                        if (visited.Contains(n))
                            continue;

                        toCheck.Enqueue(n);
                    }
                }
            }
        }

        foreach (Tile v in visited)
        {
            if (dist[v] <= unit.moveSpeed)
            {
                path.Add(v);
            }
        }

        foreach (Tile v in path)
        {
            Debug.Log("Node X: " + v.x + " Y: " + v.y + " Dist: " + dist[v]);

            Transform tile = tiles[v.y, v.x].GetComponent<Transform>();

            Renderer[] rs = tile.GetComponentsInChildren<Renderer>();
            foreach (Renderer r in rs)
            {
                Material m = r.material;
                m.color = Color.green;
                r.material = m;
            }
        }
    }
    */

    /*
     * Closed list is the generated path 
     * Might be improved with priority queue
     */
}
