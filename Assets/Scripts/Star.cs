
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Star : MonoBehaviour
{
    public string starName;
    public float x;
    public float y;
    public string size;
    public string color;
    public float distSol; //what is this?
    public string fleet;
    public List<Planet> planets = new List<Planet>();


    
    

    public Star(string starName)
    {
        this.starName = starName;
    }

    public Planet GetPlanetByName(string planetName)
    {
        foreach (Planet planet in planets)
        {
            if (planet.planetName == planetName)
            {
                return planet;
            }
        }

        return null;
    }

    public void Initialize(Cluster cluster)
    {
        var transform1 = transform;
        transform1.position = new Vector3(x, y, 0);
        transform1.localScale = GetStarSize();
        transform1.parent = cluster.transform;
        gameObject.name = starName;
        GetComponent<SpriteRenderer>().color = GetStarColor();
        
    }

    public Color GetStarColor()
    {
        switch (color.ToLower())
        {
            case "red": return Color.red;
            case "blue": return Color.blue;
            case "yellow": return Color.yellow;
            case "green": return Color.green;
            case "orange": return Color.red + Color.yellow;
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
            case "giant": scale = 2.8f;
                break;
            case "super giant": scale = 3.0f;
                break;
            default: scale = 10.0f;
                break;
        }

        return new Vector3(scale, scale, scale);
    }
}


