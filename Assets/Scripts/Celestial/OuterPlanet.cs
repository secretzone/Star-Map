using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuterPlanet : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private PlanetData _planetData;
    public ClickableOuterPlanet clickablePlanet;
    
    // Start is called before the first frame update
    private void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame

    public void Initialize(PlanetData planetData)
    {
        _planetData = planetData;
        // rotateScript.distance = _planet.
    }
}
