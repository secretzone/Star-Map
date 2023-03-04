using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    public static SolarSystem instance;
    public List<Planet> planets;
    public GameObject sun;

    public void Initialize(Star _star)
    {
        sun = Instantiate(_star.innerSystem, transform.position, Quaternion.identity, transform);
        sun.gameObject.SetActive(true);
        // foreach (var planet in _star.planets)
        // {
        //     planets.Add(Instantiate(planet)); //TODO: Positioning?
        //     planet.gameObject.SetActive(true);
        // }
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
