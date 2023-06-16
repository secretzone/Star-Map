using System;
using Data;
using Managers;
using UnityEngine;

namespace Clickable
{
    public class Star : MonoBehaviour
    {
        private StarData _starData;
        private SpriteRenderer _spriteRenderer;
        private bool _displaying;
        private bool _inProgress;
        private bool _initialized = false;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        
        public void Initialize(StarData star)
        {
            _starData = star;
            GetComponent<SpriteRenderer>().color = _starData.GetStarColor();
            transform.localScale = _starData.GetStarSize();
            gameObject.name = _starData.GetFullName();
            _initialized = true;
        }
    
        void OnMouseOver()
        {
            if (!_initialized) return;
            
            if (!_displaying) //just need to run this once
            {
                _displaying = true;
                StarMap.instance.ShowStarNameText($"{_starData.GetFullName()}", 
                    _starData.GetPosition(), 
                    _starData.GetStarColor());
            
            }
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log($"Clicked {_starData.name}");
                GameManager.instance.ShowSolarSystemView(_starData);
            }     
        
        }
    
        private void OnMouseExit()
        {
            if (!_initialized) return;
            
            _displaying = false;
            StarMap.instance.HideStarNameText();
        }
    }
}
