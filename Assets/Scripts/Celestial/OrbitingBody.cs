
using UnityEngine;

namespace Celestial
{
   public class OrbitingBody : MonoBehaviour
   {
      // private PlanetData _planetData;
      private bool _initialized = false;
      private float _rotationAngle = 0f;
      private float _distance;

      public float rotationSpeed = 0.001f;

      public void Initialize(GameObject body, float distance, float initialRotation)
      {
      
      }

   }
}
