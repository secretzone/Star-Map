using System.Collections.Generic;
using Celestial;
using Clickable;
using Data;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Managers
{
    public class PlanetSystem : MonoBehaviour
    {
        public static PlanetSystem instance;
        private StarData _starData;
        private List<ClickableMoon> _moons;
        private List<OrbitPoint> _orbits;
        private ClickableInnerPlanet _planet;
        private PlanetData _planetData;

        [Header("Prefabs")] 
        public ClickableInnerPlanet clickableInnerPlanetPrefab;
        public ClickableMoon clickableMoonPrefab;
        public OrbitPoint orbitPointPrefab;
        
        [Header("UI")]
        public GameObject ui;
        public TextMeshProUGUI innerSystemName;
        public TextMeshProUGUI innerSystemCoords;
    
        [Header("Scale")]
        public float orbitSpeed = 0.001f;
        public float distanceScale = 0.001f;
        public float rotationOffset = 70f;
        public float moonSeparationDistance = 1f;
        public float minDistanceFromPlanet = 1f;

        void Start()
        {
            if (instance == null)
            {
                instance = this;
                _starData = GameManager.instance.activeSystem;
                _planetData = GameManager.instance.activeInnerSystem;
                _moons = new List<ClickableMoon>();
                _orbits = new List<OrbitPoint>();
                innerSystemName.text = _planetData.name;
                innerSystemCoords.text = _starData.GetPosition2D().ToString();
                SpawnBodies();
            }
            else
            {
                Destroy(gameObject);
            }

        }

        private void SpawnBodies()
        {
            ClearBodies();
            Debug.Log("Spawning main planet");
            _planet = Instantiate(clickableInnerPlanetPrefab, transform.position, Quaternion.identity, transform);
            _planet.Initialize(_planetData);
        
            Debug.Log("Spawning moons");
            for (int i = 0; i < _planetData.moons.Count; i++)
            {
                OrbitPoint o = Instantiate(orbitPointPrefab, transform.position, Quaternion.identity, transform);
                ClickableMoon m = Instantiate(clickableMoonPrefab, transform.position, 
                    Quaternion.identity, o.transform);
                o.orbitingBody = m.gameObject;
                o.orbitSpeed = orbitSpeed;
                o.distance = ((i + moonSeparationDistance) * distanceScale) + minDistanceFromPlanet;
                m.Initialize(_planetData.moons[i], i);
                _moons.Add(m);
                _orbits.Add(o);
            }
            Debug.Log("Done spawning");
        }

        private void ClearBodies()
        {
            if (_planet != null) Destroy(_planet.gameObject);
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

            _moons = new List<ClickableMoon>();
            _orbits = new List<OrbitPoint>();
        }

        public void GoToSystemView()
        {
            Debug.Log("Going back");
            GameManager.instance.ShowSolarSystemView(_starData);
        }
        
        public void ResetSystem()
        {
            ClearBodies();
            SpawnBodies();
        }

    }
}
