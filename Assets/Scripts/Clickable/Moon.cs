
using Celestial;
using Data;
using UnityEngine;

namespace Clickable
{
    public class Moon : MonoBehaviour
    {
        private PlanetData _planetData;
        private SpriteRenderer _spriteRenderer;
        private bool _initialized = false;
        private OrbitPoint _orbit;
    
        public void Initialize(PlanetData planetData, OrbitPoint orbitPoint)
        {
            _orbit = orbitPoint;
            _planetData = planetData;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.color = _planetData.GetPlanetColor();
            
            _initialized = true;
        }
    }
}

