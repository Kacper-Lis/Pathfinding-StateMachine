using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class MapParser
{
    private static char delimiter = ' ';

    public static List<string[]> getMapData(StreamReader file) 
    {
        List<string[]> data = new List<string[]>();
        readFile(file, data);
        return data;
    }

    private static void readFile(StreamReader stream, List<string[]> data) 
    {
        string line;
        while ((line = stream.ReadLine()) != null) 
        {
            data.Add(splitLine(line));
        }
    }

    private static string[] splitLine(string line) 
    {
        return line.Split(delimiter);
    }
}
