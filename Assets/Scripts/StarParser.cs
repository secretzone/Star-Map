using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class StarParser : MonoBehaviour
{
    private bool inProgress = false;

    public GameObject clusterPrefab;
    public GameObject starPrefab;
    public GameObject planetPrefab;

    /**
     * These should match the order of the columns in the csv
     */
    enum Columns
    {
        Cluster = 0,
        Index,
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
    
    [Serializable]
    public class StarCluster
    {
        public String name;
        public List<Star> stars = new List<Star>();

        public StarCluster(String name)
        {
            this.name = name;
        }

        public Star GetStarByName(String starName)
        {
            foreach (Star star in stars)
            {
                if (star.name == starName)
                {
                    return star;
                }
            }

            return null;
        }
        
    }

    [Serializable]
    public class Star
    {
        public string name;
        public float x;
        public float y;
        public string size;
        public string color;
        public List<Planet> planets = new List<Planet>();

        public Star(String name)
        {
            this.name = name;
        }

        public Planet GetPlanetByName(string planetName)
        {
            foreach (Planet planet in planets)
            {
                if (planet.name == planetName)
                {
                    return planet;
                }
            }

            return null;
        }
    }

    [Serializable]
    public class Planet
    {
        public string name; //III, IV, etc
        public string type;
        public int hazard;
        public int tectonics;
        public int weather;
        public int thermal;
        public int bioUnits;
        public int minValue;
        public int minVolume;
        public float fuel;
        public int axialTilt;
        public int density;
        public int radius;
        public int gravity;
        public int temperature;
        public int day;
        public int atmosphere;
        public int lifeChance;
        public int distFromStar;

        public List<Planet> children = new List<Planet>();
        public Planet(String name)
        {
            this.name = name;
        }

    }

    public List<StarCluster> starClusters;
    
    public TextAsset systemsCsv;
    // Start is called before the first frame update
    void Start()
    {
        ParseSystemData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ParseSystemData()
    {
        StartCoroutine(ReadStarDataCsv());
        StartCoroutine(SpawnPlanets());
    }
    
    public IEnumerator ReadStarDataCsv()
    {
        if (inProgress)
        {
            yield return null;
        }

        inProgress = true;
        starClusters = new List<StarCluster>();
        var dataset = systemsCsv;
        var dataLines = dataset.text.Split('\n'); // Split also works with simple arguments, no need to pass char[]
        
        for(int i = 1; i < dataLines.Length; i++) {
            var data = dataLines[i].Split(',');

            //CLUSTER
            String clusterName = data[(int) Columns.Cluster];
            StarCluster cluster = GetClusterByName(clusterName);
            if (cluster == null)
            {
                cluster = new StarCluster(clusterName);
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



                star.planets.Add(planet);
                
            }

        }
        
        SeparateMoons();
        
        inProgress = false;
        Debug.Log("Done parsing and sorting");
        yield return null;
    }


    public void SeparateMoons()
    {
        foreach (StarCluster starCluster in starClusters)
        {
            foreach (Star star in starCluster.stars)
            {
                List<Planet> parentPlanets = new List<Planet>();
                foreach (Planet planet in star.planets)
                {
                    if (planet.name.Contains("-")) //I am a moon
                    {
                        Planet parent = star.GetPlanetByName(planet.name.Split("-")[0]);
                        if (parent == null)
                        {
                            Debug.Log($"Could not find parent for {planet.name}");
                        }
                        else
                        {
                            if (parent != planet)
                            {
                                parent.children.Add(planet);
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

    public StarCluster GetClusterByName(String name)
    {
        foreach (StarCluster cluster in starClusters)
        {
            if (cluster.name.Equals(name))
            {
                return cluster;
            }
        }

        return null;
    }

    public IEnumerator SpawnPlanets()
    {
        if (inProgress)
        {
            yield return null;
        }

        inProgress = true;
        foreach (StarCluster cluster in starClusters)
        {
            GameObject c = Instantiate(clusterPrefab);
            foreach (Star star in cluster.stars)
            {
                Vector3 pos = new Vector3(star.x, star.y, 0);
                GameObject s = Instantiate(starPrefab, pos, Quaternion.identity);
                s.transform.parent = c.transform;
            }
        }

        inProgress = false;
        yield return null;
    }
}
