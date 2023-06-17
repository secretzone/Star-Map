using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public class StarParser : MonoBehaviour
    {
        public static StarParser instance;
        public TextAsset systemsCsv;
    
        public List<ClusterData> starClusters;

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
            DistFromStar,
            SystemSize,
            SurfaceType,
            SystemColor,
            ColorHexCode
        }

        public void ParseSystemData()
        {
            starClusters = new List<ClusterData>();
            var dataset = systemsCsv;
            var dataLines = dataset.text.Split('\n'); // Split also works with simple arguments, no need to pass char[]

            for (int i = 1; i < dataLines.Length; i++)
            {
                try
                {
                    var data = dataLines[i].Split(',');

                    //CLUSTER
                    String clusterName = data[(int) Columns.Cluster];
                    ClusterData clusterData = GetClusterByName(clusterName);
                    if (clusterData == null)
                    {
                        clusterData = new ClusterData(clusterName);
                        starClusters.Add(clusterData);
                    }

                    //STARS
                    String starName = data[(int) Columns.Star]; //Prime, Alpha, etc
                    StarData starData = clusterData.GetStarByName(starName);
                    if (starData == null)
                    {
                        starData = new StarData(starName);
                        starData.x = float.Parse(data[(int) Columns.X]);
                        starData.y = float.Parse(data[(int) Columns.Y]);
                        starData.color = data[(int) Columns.StarColor];
                        starData.size = data[(int) Columns.StarSize];
                        starData.distSol = float.Parse(data[(int) Columns.DistSol]);
                        starData.fleet = data[(int) Columns.Fleet];
                        starData.parentCluster = clusterData;
                        clusterData.stars.Add(starData);
                    
                    }

                    //PLANETS
                    String planetName = data[(int) Columns.Planet];
                    PlanetData planetData = starData.GetPlanetByName(planetName);
                    if (planetData == null)
                    {
                        planetData = new PlanetData(planetName);
                        planetData.atmosphere = Convert.ToInt32(data[(int) Columns.Atmosphere]);
                        planetData.day = Convert.ToInt32(data[(int) Columns.Day]);
                        planetData.density = Convert.ToInt32(data[(int) Columns.Density]);
                        planetData.fuel = float.Parse(data[(int) Columns.Fuel]);
                        planetData.gravity = Convert.ToInt32(data[(int) Columns.Gravity]);
                        planetData.hazard = Convert.ToInt32(data[(int) Columns.Hazard]);
                        planetData.radius = Convert.ToInt32(data[(int) Columns.Radius]);
                        planetData.tectonics = Convert.ToInt32(data[(int) Columns.Tectonics]);
                        planetData.temperature = Convert.ToInt32(data[(int) Columns.Temp]);
                        planetData.thermal = Convert.ToInt32(data[(int) Columns.Thermal]);
                        planetData.type = data[(int) Columns.Type];
                        planetData.weather = Convert.ToInt32(data[(int) Columns.Weather]);
                        planetData.axialTilt = Convert.ToInt32(data[(int) Columns.AxialTilt]);
                        planetData.bioHazard = Convert.ToInt32(data[(int) Columns.BioHazard]);
                        planetData.bioUnits = Convert.ToInt32(data[(int) Columns.BioUnits]);
                        planetData.lifeChance = Convert.ToInt32(data[(int) Columns.LifeChance]);
                        planetData.minValue = Convert.ToInt32(data[(int) Columns.MinValue]);
                        planetData.minVolume = Convert.ToInt32(data[(int) Columns.MinVolume]);
                        planetData.distFromStar = Convert.ToInt32(data[(int) Columns.DistFromStar]);
                        planetData.systemSize = data[(int) Columns.SystemSize];
                        planetData.surfaceType = data[(int) Columns.SurfaceType];
                        planetData.systemColor = data[(int) Columns.SystemColor];
                        planetData.colorHexCode = data[(int) Columns.ColorHexCode];
                    
                        planetData.parentStar = starData;
                        starData.planets.Add(planetData);
                    }
                }
                catch (Exception e)
                {
                    Debug.Log($"{e.Message}:{dataLines[i]}");
                }
            }

            SeparateMoons();
            Debug.Log("Done parsing and sorting");
        }


        public void SeparateMoons()
        {
            foreach (ClusterData starCluster in starClusters)
            {
                foreach (StarData star in starCluster.stars)
                {
                    List<PlanetData> parentPlanets = new List<PlanetData>();
                    foreach (PlanetData planet in star.planets)
                    {
                        if (planet.planet.Contains("-")) //I am a moon
                        {
                            PlanetData parent = star.GetPlanetByName(planet.planet.Split("-")[0]);
                            if (parent == null)
                            {
                                Debug.Log($"Could not find parent for {planet.planet}");
                            }
                            else
                            {
                                if (parent != planet)
                                {
                                    parent.moons.Add(planet);
                                
                                    planet.isMoon = true;
                                    planet.parent = parent;
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

        public ClusterData GetClusterByName(String name)
        {
            foreach (ClusterData cluster in starClusters)
            {
                if (cluster.name.Equals(name))
                {
                    return cluster;
                }
            }

            return null;
        }
    
    }
}