using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class OuterPlanet : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    [FormerlySerializedAs("_planetData")] public PlanetData planetData;
    public ClickableOuterPlanet clickablePlanet;
    public RotateAndOrbit rotationScript;

    // Start is called before the first frame update
    private void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame

    public void Initialize(PlanetData planetData)
    {
        this.planetData = planetData;
        // clickablePlanet.transform.localScale = this.planetData.GetPlanetSize();
        rotationScript.distance = this.planetData.GetPlanetDistance();
        // rotateScript.distance = _planet.
    }
}
