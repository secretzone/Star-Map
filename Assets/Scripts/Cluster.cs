
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Cluster : CelestialObject
{
    public string clusterName;
    public List<Star> stars = new List<Star>();

    void Start()
    {
        
    }
    
    public Cluster(string clusterName)
    {
        this.clusterName = clusterName;
    }

    public Star GetStarByName(string starName)
    {
        foreach (Star star in stars)
        {
            if (star.starName == starName)
            {
                return star;
            }
        }

        return null;
    }

    public void Initialize(GameObject parent)
    {
        gameObject.name = clusterName;
        transform.parent = parent.transform;
    }
}