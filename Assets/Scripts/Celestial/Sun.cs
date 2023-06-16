using System;
using Data;
using UnityEngine;

namespace Celestial
{
    public class Sun : MonoBehaviour
    {
        private StarData _starData;
        private SpriteRenderer _spriteRenderer;
        private bool _initialized = false;

        public void Initialize(StarData star)
        {
            _starData = star;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            SetSprite();
            transform.localScale = _starData.GetStarSize();
            _initialized = true;
        }
        
        public void SetSprite()
        {
            var s = _starData.GetSunSprite();
            if (s != null)
            {
                _spriteRenderer.sprite = s;
            }
        }
    }
}
