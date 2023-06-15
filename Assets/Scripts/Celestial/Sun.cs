using Data;
using UnityEngine;

namespace Celestial
{
    public class Sun : MonoBehaviour
    {
        public StarData starData;
        private SpriteRenderer _spriteRenderer;

        public void Initialize(StarData star)
        {
            starData = star;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.color = star.GetStarColor();
        }
    }
}
