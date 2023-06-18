using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using Utility;

// [Serializable]
namespace Data
{
    public class PlanetData
    {
        [Header("Parsed data")]
        public string planet; //III, IV, etc
        public string type;
        public int hazard;
        public int tectonics;
        public int weather;
        public int thermal;
        public int bioHazard;
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
        public string systemSize;
        public string surfaceType;
        public string systemColor;
        public string colorHexCode;
        public int variant = 0;

        Dictionary<string, int> _numerals = new Dictionary<string, int>
        {
            {"I", 1}, {"II", 2}, {"III", 3}, {"IV", 4}, {"V", 5}, 
            {"VI", 6}, {"VII", 7}, {"VIII", 8}, {"IX", 9}, {"X", 10}
        };

        private Dictionary<string, int> _alphas = new Dictionary<string, int>
        {
            {"a", 1}, {"b", 2}, {"c", 3}, {"d", 4}, {"e", 5},
            {"f", 6}, {"g", 7}, {"h", 8}, {"i", 9}, {"j", 10}
        };

    
        [Header("Config")]
        public bool isMoon = false;

        public float planetScale = 0.01f;
        public float distanceScale = 0.001f;
    
        [NonSerialized]
        public PlanetData parent;
        [NonSerialized]
        public StarData parentStar;
        [NonSerialized]
        public List<PlanetData> moons = new List<PlanetData>();
    
        public PlanetData(string planet)
        {
            this.planet = planet;
        }

        public Color GetPlanetColor()
        {
            return Conversions.ColorFromString(systemColor);
        }

        public String GetType()
        {
            Regex rgx = new Regex("[^a-zA-Z]");
            String pType = type.ToLower();
            return rgx.Replace(pType, "");
        }

        public Sprite GetInnerPlanetSprite()
        {
            String pType = GetType();

            if (pType == "gasgiant")
            {
                String c = string.IsNullOrEmpty(systemColor) ? "grey" : systemColor;
                pType = $"{pType}_{c}";
            }

            String path = $"Bodies/Planet/{pType}";
            Debug.Log(path);
            return Resources.Load<Sprite>(path);
        }

        public Sprite GetWorldSprite()
        {
            String pType = GetType();
            String path = $"Worlds/{pType}_4x4";
            Debug.Log(path);
            return Resources.LoadAll<Sprite>(path)[variant];
        }

        public int GetPosition()
        {
            String[] t = planet.Split("-");
            int order = 0;
            if (isMoon)
            {
                _alphas.TryGetValue(t[1], out order);
            }
            else
            {
                _numerals.TryGetValue(t[0], out order);
            }

            return order;
        }
    }
}
