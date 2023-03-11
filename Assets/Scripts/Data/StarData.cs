
using System;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
// [Serializable]
public class StarData
{
    // public SolarSystem solarSystem; 
    public string name;
    public float x;
    public float y;
    public string size;
    public string color;
    public float distSol; //what is this?
    public string fleet;
    [NonSerialized]
    public List<PlanetData> planets = new List<PlanetData>();
    [NonSerialized]
    public ClusterData parentCluster;

    public Vector3 GetPosition()
    {
        return new Vector3(x, y, 0f);
    }

    public StarData(string name)
    {
        this.name = name;
    }

    public PlanetData GetPlanetByName(string planetName)
    {
        foreach (PlanetData planet in planets)
        {
            if (planet.name == planetName)
            {
                return planet;
            }
        }

        return null;
    }
    
    public Color GetStarColor()
    {
        switch (color.ToLower())
        {
            case "red": return Color.red;
            case "blue": return Color.blue;
            case "yellow": return Color.yellow;
            case "green": return Color.green;
            case "orange": return new Color(255, 165, 0, 1);
            default: return Color.white;
        }
    }

    public Vector3 GetStarSize()
    {
        float scale;
        switch (size)
        {
            case "dwarf": scale = 2.5f;
                break;
            case "giant": scale = 3.5f;
                break;
            case "super giant": scale = 5.0f;
                break;
            default: scale = 80.0f; //debug to make it obvious
                break;
        }

        return new Vector3(scale, scale, scale);
    }

    public String GetFullName()
    {
        return $"{name} {parentCluster.name}";
    }
}


