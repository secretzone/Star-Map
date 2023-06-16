using Celestial;
using Data;
using Managers;
using SOTemplates;
using UnityEngine;
using Utility;

namespace Clickable
{
    public class OuterPlanet : MonoBehaviour
    {
        public OuterPlanetSpritesSO rotationSprites;
        public float rotationOffset = -70;
        private PlanetData _planetData;
        private Transform _target;
        private SpriteRenderer _spriteRenderer;
        private bool _initialized = false;
    
        private Sprite[] _spriteSet;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if(!_initialized) return;
        
            SpriteIndexFromRotation();
        }

        public void Initialize(PlanetData planetData, OrbitPoint orbitPoint)
        {
            _target = orbitPoint.transform;
            _planetData = planetData;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteSet = GetSpriteSet();
            _spriteRenderer.color = _planetData.GetPlanetColor();
            
            _initialized = true;
        }



    
        private Sprite[] GetSpriteSet()
        {
            switch (_planetData.systemSize.ToLower())
            {
                case "small": return rotationSprites.smallPlanet;
                case "large": return rotationSprites.largePlanet;
                case "giant": return rotationSprites.giantPlanet;
                default: return rotationSprites.largePlanet;
            }
        }
    
    

        private void SpriteIndexFromRotation()
        {
            int imageCount = _spriteSet.Length;
            float angle = _target.rotation.eulerAngles.z + rotationOffset;
            angle = Limits.Constrain(angle, 360f, 0f);
            float degreesPerSprite = 360f / imageCount;
            int index = Mathf.RoundToInt(angle / degreesPerSprite);
            index = Limits.Constrain(index, imageCount, 1);
            _spriteRenderer.sprite = _spriteSet[index - 1];
        }

        void OnMouseOver()
        {
            //TODO: Show tooltip
        
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log($"Clicked {_planetData.name}");
                GameManager.instance.ShowInnerSystemView(_planetData);
            }  
        }
    }
}
