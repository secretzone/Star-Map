using Celestial;
using Data;
using UnityEngine;

namespace Managers
{
    public class WorldSystem : MonoBehaviour
    {
        public static WorldSystem instance;
        private PlanetData _planetData;
        private World _world;
        
        public World worldPrefab;

        
        // Start is called before the first frame update
        void Start()
        {
            if (instance == null)
            {
                instance = this;
                _planetData = GameManager.instance.activeFocusedPlanet;
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

        public void SpawnBodies()
        {
            _world = Instantiate(worldPrefab, transform.position, Quaternion.identity, transform);
            _world.Initialize(_planetData);
        }

        public void GoToPlanetSystemView()
        {
            GameManager.instance.ShowPlanetSystemView();
        }
    }
}
