
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
        public float scale = 0.3f;
    
        public void Initialize(PlanetData planetData, OrbitPoint orbitPoint)
        {
            _orbit = orbitPoint;
            _planetData = planetData;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.color = _planetData.GetPlanetColor();
            transform.localScale = new Vector3(scale, scale, scale);
            SetSprite();
            _initialized = true;
        }

        public void SetSprite()
        {
            Sprite s = _planetData.GetInnerPlanetSprite();
            if (s != null)
            {
                _spriteRenderer.sprite = s;
            }
        }
    }
}

