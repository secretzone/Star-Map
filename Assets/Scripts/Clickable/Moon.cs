
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
    
        public void Initialize(PlanetData planetData, OrbitPoint orbitPoint)
        {
            _planetData = planetData;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.color = _planetData.GetPlanetColor();
            // transform.position = new Vector3(distance, 0, 0);
            _initialized = true;
        }
    }
}

