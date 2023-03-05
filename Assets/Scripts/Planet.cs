
using System;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Planet : CelestialObject
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

    public float orbitSpeed = 1f;
    
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
        transform.parent = star.solarSystem.transform;
        gameObject.name = planetName;
        float distance = isMoon ? Math.Max(distFromStar / 1000, 1) : 1;
        GetComponent<RotateAndOrbit>().desiredMoonDistance = distance;
        //TODO
    }

    // public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion angle) {
    //     return angle * ( point - pivot) + pivot;
    // }
    //
    // void Update()
    // {
    //     transform.position = 
    //         RotatePointAroundPivot(transform.position,
    //             transform.parent.position,
    //             Quaternion.Euler(0, OrbitDegrees * Time.deltaTime, 0));
    // }

    
}
