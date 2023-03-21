
using UnityEngine;

[CreateAssetMenu(fileName = "OuterPlanetSprites", menuName = "ScriptableObjects/OuterPlanetSprites", order = 1)]

public class OuterPlanetSpritesSO : ScriptableObject
{
    [Header("Rotational shade sprites")]
    public Sprite[] smallPlanet;
    public Sprite[] largePlanet;
    public Sprite[] giantPlanet;
}
