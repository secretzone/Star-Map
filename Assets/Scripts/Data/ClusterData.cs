
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
// [Serializable]
public class ClusterData
{
    public string name;
    [NonSerialized]
    public List<StarData> stars = new List<StarData>();

    public ClusterData(string name)
    {
        this.name = name;
    }

    public StarData GetStarByName(string starName)
    {
        foreach (StarData star in stars)
        {
            if (star.name == starName)
            {
                return star;
            }
        }

        return null;
    }
}