using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    public Star star;
    public List<Planet> planets;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize()
    {
        //set up orbits
    }
    
    public void EnablePlanets(bool enabled)
    {
        foreach (Planet planet in planets)
        {
            planet.EnableMoons(enabled);
            planet.gameObject.SetActive(enabled);
        }
    }
}
