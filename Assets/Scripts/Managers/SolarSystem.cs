using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    public static SolarSystem instance;
    private StarData _starData;
    private Sun _sun;
    private List<OuterPlanet> _planets;

    [Header("Prefabs")]
    public OuterPlanet outerPlanetPrefab;
    public Sun sunPrefab;

    [Header("UI")]
    public GameObject ui;
    public TextMeshProUGUI solarSystemName;
    public TextMeshProUGUI solarSystemCoords;

    [Header("Scale")]
    public float rotationSpeed = 0.001f;
    public float distanceScale = 0.001f;
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        
        
        _starData = GameManager.instance.activeSystem;
        _planets = new List<OuterPlanet>();
        solarSystemName.text = _starData.GetFullName();
        solarSystemCoords.text = _starData.GetPosition2D().ToString();
        SpawnBodies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnBodies()
    {
        ClearBodies();
        _sun = Instantiate(sunPrefab, transform.position, Quaternion.identity, transform);
        _sun.Initialize(_starData);
        foreach (PlanetData planet in _starData.planets)
        {
            OuterPlanet p = Instantiate(outerPlanetPrefab, _sun.transform.position, Quaternion.identity,
                _sun.transform);
            p.Initialize(planet);
            _planets.Add(p);
        }
    }

    //Needed? We reset when the scene loads
    private void ClearBodies()
    {
        if (_sun != null) Destroy(_sun.gameObject);
        if (_planets != null && _planets.Count > 0)
        {
            foreach (OuterPlanet planet in _planets)
            {
                if (planet != null)
                {
                    Destroy(planet.gameObject);
                }

            }
        }

        _planets = new List<OuterPlanet>();
    }

    public void GoToStarMap()
    {
        GameManager.instance.ShowStarMapView();
    }
    
}
