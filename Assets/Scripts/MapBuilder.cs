using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MapBuilder : MonoBehaviour
{
    [HideInInspector] public GenerateMap grid;
    [HideInInspector] public GenerateUnit units;

    public string map_filename;
    public string units_filename;
    private List<string[]> mapData;
    private List<string[]> unitsData;

    public void setup()
    {
        StreamReader stream = new StreamReader(@"Assets\Maps\" + map_filename);
        mapData = MapParser.getMapData(stream);
        stream = new StreamReader(@"Assets\Maps\" + units_filename);
        unitsData = MapParser.getMapData(stream);
        stream.Close();

        grid = GetComponentInChildren<GenerateMap>();
        units = GetComponentInChildren<GenerateUnit>();

        grid.setup(mapData);
        units.setup(unitsData, grid.getWidth(), grid.getHeight(), grid);
    }
}
