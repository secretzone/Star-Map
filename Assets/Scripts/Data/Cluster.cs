
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Cluster
{
    public string clusterName;
    public List<Star> stars = new List<Star>();

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
}