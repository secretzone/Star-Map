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
            _spriteRenderer.color = star.GetStarColor();

            _initialized = true;
        }
    }
}
