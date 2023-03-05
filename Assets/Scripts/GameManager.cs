using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public Camera starMapCamera;
    public Camera solarSystemCamera;
    public GameObject starMap;
    
    public Canvas starMapCanvas;
    public Canvas solarSystemCanvas;
    public GameObject solarSystemAnchor;
    
    public static GameManager instance;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this); //There can be only one
        }
        
        ShowStarMapView();
    }

    public void ShowStarMapView()
    {
        solarSystemCamera.gameObject.SetActive(false);
        solarSystemCanvas.gameObject.SetActive(false);
        solarSystemAnchor.GetComponent<SolarSystemSpawner>().ClearSystem();
        
        starMapCamera.gameObject.SetActive(true);
        starMapCanvas.gameObject.SetActive(true);
        starMap.SetActive(true);
    }

    public void ShowSolarSystemView()
    {
        starMapCamera.gameObject.SetActive(false);
        starMapCanvas.gameObject.SetActive(false);
        starMap.SetActive(false);
        
        solarSystemCamera.gameObject.SetActive(true);
        solarSystemCanvas.gameObject.SetActive(true);

        // solarSystemAnchor.SetActive(true);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
