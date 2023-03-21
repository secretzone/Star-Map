using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class OuterPlanet : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public PlanetData planetData;
    public ClickableOuterPlanet clickablePlanet;
    // public RotateAndOrbit rotationScript;

    // Start is called before the first frame update
    private void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame

    public void Initialize(PlanetData planetData)
    {
        this.planetData = planetData;
        //set initial rotation
        clickablePlanet.Initialize(planetData, GetPlanetDistance());
        
        // rotationScript.distance = this.planetData.GetPlanetDistance();
    }
    
    public float GetPlanetDistance()
    {
        return planetData.distFromStar * SolarSystem.instance.distanceScale;
    }
}
