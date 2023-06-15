using Data;
using UnityEngine;

namespace Clickable
{
    public class ClickableInnerPlanet : MonoBehaviour
    {
        private PlanetData _planetData;
        private SpriteRenderer _spriteRenderer;
        private bool _initialized = false;
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
}
