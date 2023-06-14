using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableInnerPlanet : MonoBehaviour
{
    private PlanetData _planetData;
    private SpriteRenderer _spriteRenderer;
    private bool _initialized = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(PlanetData planetData)
    {
        _planetData = planetData;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = _planetData.GetPlanetColor();
        
        _initialized = true;
    }
}
