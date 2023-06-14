using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InnerPlanet : MonoBehaviour
{
    // Start is called before the first frame update
    private PlanetData _planetData;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(PlanetData planetData)
    {
        _planetData = planetData;
    }
}
