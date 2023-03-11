using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    private StarData _starData;
    private Sun _sun;
    private List<OuterPlanet> _planets;

    public OuterPlanet outerPlanetPrefab;

    public Sun sunPrefab;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _planets = new List<OuterPlanet>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnBodies(StarData starData)
    {
        _starData = starData;
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

    public void ClearBodies()
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
    
}
