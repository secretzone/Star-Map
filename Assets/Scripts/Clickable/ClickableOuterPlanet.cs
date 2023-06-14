using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableOuterPlanet : MonoBehaviour
{
    public OuterPlanetSpritesSO rotationSprites;
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

    public void Initialize(PlanetData planetData, float distance)
    {
        _planetData = planetData;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteSet = GetSpriteSet();
        var transform1 = transform;
        transform1.position = new Vector3(distance, 0, 0);
        _target = transform1.parent;
        _initialized = true;
        _spriteRenderer.color = _planetData.GetPlanetColor();
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
        float angle = _target.rotation.eulerAngles.z + SolarSystem.instance.rotationOffset;
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
