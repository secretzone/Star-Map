using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class OuterPlanet : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public PlanetData planetData;
    public ClickableOuterPlanet clickablePlanet;
    private bool _initialized = false;

    public float rotationAngle = 0f;
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
        clickablePlanet.Initialize(planetData, GetPlanetDistance());
        float scale = SolarSystem.instance.planetScale;
        clickablePlanet.transform.localScale = new Vector3(scale, scale, scale);
        
        rotationAngle = Random.Range(0f, 360f);
        UpdatePosition();
        
        _initialized = true;
        // rotationScript.distance = this.planetData.GetPlanetDistance();
    }
    
    public float GetPlanetDistance()
    {
        return planetData.distFromStar * SolarSystem.instance.distanceScale;
    }

    private void Update()
    {
        if (!_initialized) return;
        AddRotation();
        UpdatePosition();
    }

    private void AddRotation()
    {
        float step = ((SolarSystem.instance.orbitSpeed / GetPlanetDistance()) * 360) * Time.deltaTime;
        rotationAngle = Limits.Constrain(transform.eulerAngles.z + step, 0f, 360f);
    }

    private void UpdatePosition()
    {
        transform.rotation = Quaternion.Euler(transform.parent.eulerAngles.x, 0, rotationAngle);
    }
}
