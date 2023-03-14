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

    [FormerlySerializedAs("starData")] [Header("Data")]
    public StarParser starParser;
    public static GameManager instance;
    
    private bool _inProgress; //If a coroutine is busy

    public StarData activeSystem = null;
    
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Destroy(this.gameObject); //There can be only one
        }

        instance = this;
        DontDestroyOnLoad(this);
        Initialize();
        if (SceneManager.GetActiveScene().name == "LoadingScene")
        {
            SceneManager.LoadScene("StarMap");
        }
        
    }
    
    

    private void Initialize()
    {
        starParser.ParseSystemData();
        // starMap.Initialize(starParser.starClusters);
        // ShowStarMapView();
    }
    //
    // public void ShowStarMapView()
    // {
    //     //Coroutine to load star map here
    //     solarSystem.ClearBodies();
    //     solarSystemUI.Enabled(false);
    //     
    //     starMapUI.Enabled(true);
    //     starMap.gameObject.SetActive(true);
    // }
    //
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
