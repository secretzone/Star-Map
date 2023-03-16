using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

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
    
    
    // Start is called before the first frame update
    void Start()
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
        // activeSystem = starParser.starClusters[0].stars[0];
    }
    
    public void ShowStarMapView()
    {
        SceneManager.LoadScene("StarMap");
    }
    
    public void ShowSolarSystemView(StarData starData)
    {

        activeSystem = starData;
        SceneManager.LoadScene("SolarSystem");
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

}
