using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuterPlanet : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    public RotateAndOrbit rotateScript;
    
    // Start is called before the first frame update
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame

}
