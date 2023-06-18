using Data;
using UnityEngine;

namespace Celestial
{
    public class World : MonoBehaviour
    {
        private PlanetData _planetData;
        private bool _initialized = false;
        private SpriteRenderer _spriteRenderer;
        
        public void Initialize(PlanetData planetData)
        {
            _planetData = planetData;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            SetSprite();
            _initialized = true;
        }
        
        public void SetSprite()
        {
            Sprite s = _planetData.GetWorldSprite();
            if (s != null)
            {
                _spriteRenderer.sprite = s;
            }
            else
            {
                Debug.LogWarning("Sprite was null");
            }
        }
    }
}