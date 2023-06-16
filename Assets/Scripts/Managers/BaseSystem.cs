using System.Collections.Generic;
using Celestial;
using Data;
using UnityEngine;

namespace Managers
{
    public abstract class BaseSystem : MonoBehaviour
    {
        private List<OrbitPoint> _orbits;

        [Header("Prefabs")] 
        public GameObject centralBodyPrefab;
        public GameObject outerBodyPrefab;
        public OrbitPoint orbitPointPrefab;
        
        [Header("Scale")]
        public float orbitSpeed = 0.001f;
        public float distanceScale = 0.001f;
        public float separationDistance = 1f;
        public float minDistanceFromCenter = 1f;

        private GameObject _centerBody;

        public abstract List<PlanetData> GetPlanetData();
        protected void SpawnBodies()
        {
            _centerBody = Instantiate(centralBodyPrefab, transform.position, Quaternion.identity, transform);
            
        }

        private void ClearBodies()
        {
            if(_centerBody != null) Destroy(_centerBody);
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

            _orbits = new List<OrbitPoint>();
        }

        public void ResetSystem()
        {
            ClearBodies();
            SpawnBodies();
        }
    }
}