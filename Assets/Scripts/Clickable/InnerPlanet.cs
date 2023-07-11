using Data;
using Managers;
using UnityEngine;

namespace Clickable
{
    public class InnerPlanet : MonoBehaviour
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
            // _spriteRenderer.color = _planetData.GetPlanetColor();
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
            else
            {
                Debug.LogWarning("Sprite was null");
            }
        }
        
        void OnMouseOver()
        {
            //TODO: Show tooltip
        
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log($"Clicked {_planetData.planet}");
                GameManager.instance.ShowPlanetDetailsView(_planetData);
            }  
        }
    }
}
