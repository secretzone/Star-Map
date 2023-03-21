using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableOuterPlanet : MonoBehaviour
{
    public OuterPlanetSpritesSO rotationSprites;
    private PlanetData _planetData;
    public float offset = 0f;
    private Transform target;
    private SpriteRenderer _spriteRenderer;
    private bool _initialized = false;
    
    private Sprite[] spriteSet;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
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
        spriteSet = GetSpriteSet();
        transform.position = new Vector3(distance, 0, 0);
        target = transform.parent;
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
        int imageCount = spriteSet.Length;
        float angle = target.rotation.eulerAngles.z + offset;
        angle = Constrain(angle, 360f, 0f);
        float degreesPerSprite = 360f / imageCount;
        int index = Mathf.RoundToInt(angle / degreesPerSprite);
        index = Constrain(index, imageCount, 1);
        _spriteRenderer.sprite = spriteSet[index - 1];
    }
    
    /**
     * Goal here is to loop around so we aren't doing math against huge numbers.
     */
    private static float Constrain(float input, float max, float min)
    {
        float result = input;
        if (input > max)
        {
            result -= max; // 380 - 360 = 20
        }

        if (input < min)
        {
            result += max; // -20 + 360 = 340
        }

        return result;
    }
    
    private static int Constrain(int input, int max, int min)
    {
        int result = input;
        if (input > max)
        {
            result -= max; // 17 - 16 = 1
        }

        if (input < min)
        {
            result += max; // -1 + 16 = 15
        }

        return result;
    }
    
}
