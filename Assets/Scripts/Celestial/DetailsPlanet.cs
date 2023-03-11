using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DetailsPlanet : MonoBehaviour
{
    public PlanetData planetData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(PlanetData data)
    {
        this.planetData = data;
    }
}
