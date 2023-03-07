
using System;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Planet
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
    public Transform rotationReference;
    public Sprite[] rotationSprites;
    public SpriteRenderer spriteRenderer;
    public int index;
    public float angle;
    
    public List<Planet> moons = new List<Planet>();
    
    
    public Planet(string planetName)
    {
        this.planetName = planetName;
    }

    // public void EnableMoons(bool enabled)
    // {
    //     foreach (Planet moon in moons)
    //     {
    //         moon.gameObject.SetActive(enabled);
    //     }
    // }

    // public void Initialize(Star star)
    // {
    //     transform.parent = star.solarSystem.transform;
    //     gameObject.name = planetName;
    //     float distance = Math.Max(distFromStar / 1000, 1);
    //     GetComponent<RotateAndOrbit>().distance = distance;
    //     //TODO
    // }

    // private void Start()
    // {
    //     spriteRenderer = GetComponent<SpriteRenderer>();
    // }

    // private void Update()
    // {
    //     float offset = 0;
    //     int imageCount = rotationSprites.Length;
    //     angle = rotationReference.rotation.x + offset;
    //     float degreesPerSprite = 360f / imageCount;
    //     index = Mathf.RoundToInt(angle / degreesPerSprite);
    //     spriteRenderer.sprite = rotationSprites[index];
    // }
}
