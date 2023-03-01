using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera mainCamera;
    public Canvas starMapCanvas;
    public Canvas solarSystemCanvas;
    
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
