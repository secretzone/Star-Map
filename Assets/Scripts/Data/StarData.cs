using System;
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Data
{
    [Serializable]
    public class StarData
    {
        // public SolarSystem solarSystem; 
        public string name;
        public float x;
        public float y;
        public string size;
        public string color;
        public float distSol; //what is this?
        public string fleet;
        [NonSerialized]
        public List<PlanetData> planets = new List<PlanetData>();
        [NonSerialized]
        public ClusterData parentCluster;

        public Vector3 GetPosition()
        {
            return new Vector3(x, y, 0f);
        }

        public Vector2 GetPosition2D()
        {
            return new Vector2(x, y);
        }

        public StarData(string name)
        {
            this.name = name;
        }

        public PlanetData GetPlanetByName(string planetName)
        {
            foreach (PlanetData planet in planets)
            {
                if (planet.name == planetName)
                {
                    return planet;
                }
            }

            return null;
        }
    
        public Color GetStarColor()
        {
            return Conversions.ColorFromString(color);
        }

        public Vector3 GetStarSize()
        {
            float scale;
            switch (size)
            {
                case "dwarf": scale = 2.5f;
                    break;
                case "giant": scale = 3.5f;
                    break;
                case "super giant": scale = 5.0f;
                    break;
                default: scale = 80.0f; //debug to make it obvious
                    break;
            }

            return new Vector3(scale, scale, scale);
        }

        public string GetFullName()
        {
            try
            {
                return $"{name} {parentCluster.name}";
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                return "Unknown";
            }
        }
        
        public Sprite GetSunSprite()
        {
            String path = $"Bodies/System/star_{size.Replace(" ","")}_{color}";
            Debug.Log(path);
            return Resources.Load<Sprite>(path);
        }
    }
}


