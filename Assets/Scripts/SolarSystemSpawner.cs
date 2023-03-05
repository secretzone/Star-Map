using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SolarSystemSpawner : MonoBehaviour
{
    public static SolarSystemSpawner instance;
    public List<Planet> planets;
    public SolarSystem sun;
    public Star star;
    public void Initialize(Star _star)
    {
        
        //var transform1 = transform;
        //sun = Instantiate(_star.solarSystem.gameObject, transform1.position, Quaternion.identity, transform1)
        //    .GetComponent<SolarSystem>();
        //sun.gameObject.SetActive(true);
        //sun.EnablePlanets(true);
    }

    public void ClearSystem()
    {
        if (sun != null)
        {
            Destroy(sun.gameObject); 
        }
    }
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}
