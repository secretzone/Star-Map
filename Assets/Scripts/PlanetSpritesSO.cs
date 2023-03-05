using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlanetSprites", order = 1)]
public class PlanetSpritesSO : ScriptableObject
{
    [Serializable]
    public class SpriteSet
    {
        public Sprite zoom1;
        public Sprite zoom2;
        public Sprite orbitalView; 
    }

    [SerializeField]
    public SpriteSet[] SpriteSets;

}