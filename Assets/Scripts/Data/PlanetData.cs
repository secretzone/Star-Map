
using System;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
// [Serializable]
public class PlanetData
{
    [Header("Parsed data")]
    public string name; //III, IV, etc
    public string type;
    public int hazard;
    public int tectonics;
    public int weather;
    public int thermal;
    public int bioHazard;
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
    public string systemSize;
    public string surfaceType;
    public string systemColor;
    public string colorHexCode;

    
    [Header("Config")]
    public bool isMoon = false;

    public float planetScale = 0.01f;
    public float distanceScale = 0.001f;
    
    [NonSerialized]
    public PlanetData parent;
    [NonSerialized]
    public StarData parentStar;
    [NonSerialized]
    public List<PlanetData> moons = new List<PlanetData>();
    
    public PlanetData(string name)
    {
        this.name = name;
    }
}
