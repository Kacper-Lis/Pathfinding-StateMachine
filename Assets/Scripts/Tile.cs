using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
	public List<Tile> edges;

	public bool isWalkable = true;
	public int movementCost = 1;
	public Cords cords;

	public struct Cords
	{
		public int X { get; private set; }

		public int Y { get; private set; }

		public Cords(int x, int y)
		{
			X = x;
			Y = y;
		}
	}
	
    public int x { get; set; }
    public int y { get; set; }
    public int distance { get; set; }

    public static Cords FromOffsetCoordinates(int x, int y)
	{
		return new Cords(x - y / 2, y);
	}

	void OnMouseUp()
	{
		Debug.Log("X: " + x + " Y: " + y);
	}
	
}
