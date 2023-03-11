
using System;
using Unity.VisualScripting;
using UnityEngine;


public class SpriteIndexFromRotation : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public Sprite[] sprites;
    public Transform target;
    public float offset = 0f;

    public float angle;

    public int index;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        int imageCount = sprites.Length;
        angle = target.rotation.eulerAngles.z + offset;
        angle = Constrain(angle, 360f, 0f);
        float degreesPerSprite = 360f / imageCount;
        index = Mathf.RoundToInt(angle / degreesPerSprite);
        index = Constrain(index, imageCount, 1);
        _spriteRenderer.sprite = sprites[index - 1];
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
