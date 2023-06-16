using System.Collections.Generic;
using System.ComponentModel;
using Celestial;
using Clickable;
using Data;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Managers
{
    public class SolarSystem : MonoBehaviour
    {
        public static SolarSystem instance;
        private StarData _starData;
        private Sun _sun;
        private List<ClickableOuterPlanet> _planets;
        private List<OrbitPoint> _orbits;
        

        [Header("Prefabs")]
        public ClickableOuterPlanet clickableOuterPlanetPrefab;
        public OrbitPoint orbitPointPrefab;
        public Sun sunPrefab;

        [Header("UI")]
        public GameObject ui;
        public TextMeshProUGUI solarSystemName;
        public TextMeshProUGUI solarSystemCoords;

        [Header("Scale")]
        public float orbitSpeed = 0.001f;
        public float distanceScale = 1f;
        public float rotationOffset = 70f;
        public float planetSeparationDistance = 1f;
        public float minDistFromSun = 1f;
    
        // Start is called before the first frame update
        void Start()
        {
            if (instance == null)
            {
                instance = this;
                _starData = GameManager.instance.activeSystem;
                _planets = new List<ClickableOuterPlanet>();
                _orbits = new List<OrbitPoint>();
                solarSystemName.text = _starData.GetFullName();
                solarSystemCoords.text = _starData.GetPosition2D().ToString();
                SpawnBodies();
            }
            else
            {
                Destroy(gameObject);
            }
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
            
            for (int i = 0; i < _starData.planets.Count; i++)
            {
                OrbitPoint o = Instantiate(orbitPointPrefab, transform.position, Quaternion.identity, transform);
                ClickableOuterPlanet p = Instantiate(clickableOuterPlanetPrefab, transform.position, 
                    Quaternion.identity, o.transform);
                o.orbitingBody = p.gameObject;
                o.orbitSpeed = orbitSpeed;
                o.distance = ((i + planetSeparationDistance) * distanceScale) + minDistFromSun;
                // p.transform.localScale *= planetScale;
                p.Initialize(_starData.planets[i], o.transform);
                _planets.Add(p);
                _orbits.Add(o);
            }
        }

        private void ClearBodies()
        {
            if (_sun != null) Destroy(_sun.gameObject);
            if (_orbits != null && _orbits.Count > 0)
            {
                foreach (OrbitPoint o in _orbits)
                {
                    if (o.orbitingBody != null)
                    {
                        Destroy(o.orbitingBody.gameObject);
                    }
                    Destroy(o.gameObject);
                }
            }

            _planets = new List<ClickableOuterPlanet>();
            _orbits = new List<OrbitPoint>();
        }

        public void GoToStarMap()
        {
            GameManager.instance.ShowStarMapView();
        }


        public void ResetSystem()
        {
            ClearBodies();
            SpawnBodies();
        }
    }
}
