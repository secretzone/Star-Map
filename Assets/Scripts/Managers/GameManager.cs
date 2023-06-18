using Data;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {

        // [Header("UI")]
        // public StarMapUI starMapUI;
        // public SolarSystemUI solarSystemUI;
        //
        // [Header("Spawners")]
        // public StarMap starMap;
        // public SolarSystem solarSystem;


        [Header("Data")]
        public StarParser starParser;
        public static GameManager instance;
    
        private bool _inProgress; //If a coroutine is busy

        public StarData activeSystem;
        public PlanetData activeInnerSystem;
        public PlanetData activeFocusedPlanet;


        // Start is called before the first frame update
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                Initialize();
                if (SceneManager.GetActiveScene().name == "LoadingScene")
                {
                    SceneManager.LoadScene("StarMap");
                }
            }
            else
            {
                Destroy(gameObject); //There can be only one. This also lets us put this in any scene.
            }


        
        }
    
    

        private void Initialize()
        {
            starParser.ParseSystemData();
            activeSystem = starParser.starClusters[0].stars[0];
        }
    
        public void ShowStarMapView()
        {
            SceneManager.LoadScene("StarMap");
        }

        public void ShowSolarSystemView()
        {
            if (activeSystem != null)
            {
                ShowSolarSystemView(activeSystem);
            }
            else
            {
                Debug.LogError("No system was set when trying to show the solar system view");
            }
        }
    
        public void ShowSolarSystemView(StarData starData)
        {
            activeSystem = starData;
            SceneManager.LoadScene("SolarSystem");
        }

        public void ShowPlanetSystemView()
        {
            if (activeInnerSystem != null)
            {
                ShowPlanetSystemView(activeInnerSystem);
            }
            else
            {
                Debug.LogError("No system was set when trying to show an inner system");
            }
        }
    
        public void ShowPlanetSystemView(PlanetData planetData)
        {
            activeInnerSystem = planetData;
            SceneManager.LoadScene("PlanetSystem");
        }


        public void ShowPlanetDetailsView()
        {
            if (activeFocusedPlanet != null)
            {
                ShowPlanetDetailsView(activeFocusedPlanet);
            }
            else
            {
                Debug.LogError("No system was set when trying to show the planet details view");
            }
        }
        
        public void ShowPlanetDetailsView(PlanetData planetData)
        {
            activeFocusedPlanet = planetData;
            SceneManager.LoadScene("WorldSystem");
        }
    }
}
