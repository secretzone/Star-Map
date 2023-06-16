// using SOTemplates;
// using UnityEngine;
// using Utility;
//
// namespace Behavior
// {
//     public class SpriteIndexFromRotation : MonoBehaviour
//     {
//         public OuterPlanetSpritesSO rotationSprites;
//         public float rotationOffset = -70;
//         private SpriteRenderer _spriteRenderer;
//         
//         
//
//         private Sprite[] GetSpriteSet()
//         {
//             switch (_planetData.systemSize.ToLower())
//             {
//                 case "small": return rotationSprites.smallPlanet;
//                 case "large": return rotationSprites.largePlanet;
//                 case "giant": return rotationSprites.giantPlanet;
//                 default: return rotationSprites.largePlanet;
//             }
//         }
//         
//         private void UpdateSpriteIndex()
//         {
//             int imageCount = _spriteSet.Length;
//             float angle = _target.rotation.eulerAngles.z + rotationOffset;
//             angle = Limits.Constrain(angle, 360f, 0f);
//             float degreesPerSprite = 360f / imageCount;
//             int index = Mathf.RoundToInt(angle / degreesPerSprite);
//             index = Limits.Constrain(index, imageCount, 1);
//             _spriteRenderer.sprite = _spriteSet[index - 1];
//         }
//     }
// }
