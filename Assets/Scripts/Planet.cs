
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Planet : MonoBehaviour
{
    public string planetName; //III, IV, etc
    public string type;
    public int hazard;
    public int tectonics;
    public int weather;
    public int thermal;
    public int bioUnits;
    public int minValue;
    public int minVolume;
    public float fuel;
    public int axialTilt;
    public int density;
    public int radius;
    public int gravity;
    public int temperature;
    public int day;
    public int atmosphere;
    public int lifeChance;
    public int distFromStar;
    public int bioHazard;

    public bool isMoon = false;
    
    public List<Planet> moons = new List<Planet>();


    public Planet(string planetName)
    {
        this.planetName = planetName;
    }

    public void EnableMoons(bool enabled)
    {
        foreach (Planet moon in moons)
        {
            moon.gameObject.SetActive(enabled);
        }
    }

    // public void AddMoon(Planet moon)
    // {
    //     moon.transform.parent = transform;
    //     moon.isMoon = true;
    //     moons.Add(moon);
    // }

    public void Initialize(Star star)
    {
        transform.parent = star.transform;
        gameObject.name = planetName;
        //TODO
    }

}
