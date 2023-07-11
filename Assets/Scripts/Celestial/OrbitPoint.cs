
using System;
using UnityEngine;
using UnityEngine.Serialization;
using Utility;

namespace Celestial
{
   public class OrbitPoint : MonoBehaviour
   {
      // private PlanetData _planetData;
      private bool _initialized = false;
      
      

      public bool autoRotate = true;
      public float orbitSpeed = 0.001f;
      [FormerlySerializedAs("_rotationAngle")] public float rotationAngle = 0f;
      [FormerlySerializedAs("_distance")] public float distance = 1f;
      public GameObject orbitingBody;

      public void Initialize(GameObject body, float distance, float initialRotation)
      {
         orbitingBody = body;
         this.distance = distance;
         rotationAngle = initialRotation;
         orbitingBody.transform.parent = transform;
         orbitingBody.transform.position = new Vector3(this.distance, 0, 0);
         _initialized = true;
      }

      private void Start()
      {
         orbitingBody.transform.position = new Vector3(distance, 0, 0);
         _initialized = true;
      }

      // public void Initialize(float distance, float initialRotation)
      // {
      //    Initialize(orbitingBody, distance, initialRotation);
      // }
      
      private void Update()
      {
         if (!_initialized) return;
         if (autoRotate)
         {
            AddRotation();
         }
         UpdatePosition();
      }

      private void AddRotation()
      {
         float step = (orbitSpeed / distance * 360) * Time.deltaTime;
         rotationAngle = Limits.Constrain(transform.eulerAngles.z + step, 0f, 360f);
      }

      private void UpdatePosition()
      {
         transform.rotation = Quaternion.Euler(transform.parent.eulerAngles.z, 0, rotationAngle);
         orbitingBody.transform.localPosition = new Vector3(distance, 0, 0);
      }
   }
}
