using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class StarParser : MonoBehaviour
{
    public static StarParser instance;
    public TextAsset systemsCsv;
    
    public List<Cluster> starClusters;
    private bool inProgress = false;
    
    /**
     * These should match the order of the columns in the csv
     */
    enum Columns
    {
        Cluster = 0,
        Index, //always null
        Star,
        X,
        Y,
        DistSol,
        StarColor,
        StarSize,
        Fleet,
        Planet,
        Type,
        Hazard,
        Tectonics,
        Weather,
        Thermal,
        BioHazard,
        BioUnits,
        MinValue,
        MinVolume,
        Fuel,
        AxialTilt,
        Density,
        Radius,
        Gravity,
        Temp,
        Day,
        Atmosphere,
        LifeChance,
        DistFromStar
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
        ParseSystemData();
    }

    public void ParseSystemData()
    {
        StartCoroutine(ReadStarDataCsv());
    }

    public IEnumerator ReadStarDataCsv()
    {
        if (inProgress)
        {
            yield return null;
        }

        inProgress = true;
        starClusters = new List<Cluster>();
        var dataset = systemsCsv;
        var dataLines = dataset.text.Split('\n'); // Split also works with simple arguments, no need to pass char[]

        for (int i = 1; i < dataLines.Length; i++)
        {
            try
            {
                var data = dataLines[i].Split(',');

                //CLUSTER
                String clusterName = data[(int) Columns.Cluster];
                Cluster cluster = GetClusterByName(clusterName);
                if (cluster == null)
                {
                    cluster = new Cluster(clusterName);
                    starClusters.Add(cluster);
                }

                //STARS
                String starName = data[(int) Columns.Star]; //Prime, Alpha, etc
                Star star = cluster.GetStarByName(starName);
                if (star == null)
                {
                    star = new Star(starName);
                    star.x = float.Parse(data[(int) Columns.X]);
                    star.y = float.Parse(data[(int) Columns.Y]);
                    star.color = data[(int) Columns.StarColor];
                    star.size = data[(int) Columns.StarSize];
                    star.distSol = float.Parse(data[(int) Columns.DistSol]);
                    star.fleet = data[(int) Columns.Fleet];
                    cluster.stars.Add(star);
                }

                //PLANETS
                String planetName = data[(int) Columns.Planet];
                Planet planet = star.GetPlanetByName(planetName);
                if (planet == null)
                {
                    planet = new Planet(planetName);
                    planet.atmosphere = Convert.ToInt32(data[(int) Columns.Atmosphere]);
                    planet.day = Convert.ToInt32(data[(int) Columns.Day]);
                    planet.density = Convert.ToInt32(data[(int) Columns.Density]);
                    planet.fuel = float.Parse(data[(int) Columns.Fuel]);
                    planet.gravity = Convert.ToInt32(data[(int) Columns.Gravity]);
                    planet.hazard = Convert.ToInt32(data[(int) Columns.Hazard]);
                    planet.radius = Convert.ToInt32(data[(int) Columns.Radius]);
                    planet.tectonics = Convert.ToInt32(data[(int) Columns.Tectonics]);
                    planet.temperature = Convert.ToInt32(data[(int) Columns.Temp]);
                    planet.thermal = Convert.ToInt32(data[(int) Columns.Thermal]);
                    planet.type = data[(int) Columns.Type];
                    planet.weather = Convert.ToInt32(data[(int) Columns.Weather]);
                    planet.axialTilt = Convert.ToInt32(data[(int) Columns.AxialTilt]);
                    planet.bioUnits = Convert.ToInt32(data[(int) Columns.BioUnits]);
                    planet.lifeChance = Convert.ToInt32(data[(int) Columns.LifeChance]);
                    planet.minValue = Convert.ToInt32(data[(int) Columns.MinValue]);
                    planet.minVolume = Convert.ToInt32(data[(int) Columns.MinVolume]);
                    planet.distFromStar = Convert.ToInt32(data[(int) Columns.DistFromStar]);
                    planet.bioHazard = Convert.ToInt32(data[(int) Columns.BioHazard]);
                    star.planets.Add(planet);
                }
            }
            catch (Exception e)
            {
                Debug.Log($"{e.Message}:{dataLines[i]}");
            }
        }

        SeparateMoons();
        Debug.Log("Done parsing and sorting");
        inProgress = false;

        yield return null;
    }


    public void SeparateMoons()
    {
        foreach (Cluster starCluster in starClusters)
        {
            foreach (Star star in starCluster.stars)
            {
                List<Planet> parentPlanets = new List<Planet>();
                foreach (Planet planet in star.planets)
                {
                    if (planet.planetName.Contains("-")) //I am a moon
                    {
                        Planet parent = star.GetPlanetByName(planet.planetName.Split("-")[0]);
                        if (parent == null)
                        {
                            Debug.Log($"Could not find parent for {planet.planetName}");
                        }
                        else
                        {
                            if (parent != planet)
                            {
                                parent.moons.Add(planet);
                            }
                        }
                    }

                    else //Not a moon
                    {
                        parentPlanets.Add(planet);
                    }
                }

                star.planets = parentPlanets;
            }
        }
    }

    public Cluster GetClusterByName(String name)
    {
        foreach (Cluster cluster in starClusters)
        {
            if (cluster.clusterName.Equals(name))
            {
                return cluster;
            }
        }

        return null;
    }
    
}