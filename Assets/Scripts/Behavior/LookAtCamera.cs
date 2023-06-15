using UnityEngine;

namespace Behavior
{
    public class LookAtCamera : MonoBehaviour
    {
        public Camera targetCamera;

        private void Start()
        {
            // targetCamera = Camera.current;
        }

        // void Update()
        // {
        //     targetCamera = Camera.current;
        //     if (targetCamera != null)
        //     {
        //         Vector3 faceDir = new Vector3(targetCamera.transform.forward.x, targetCamera.transform.forward.y, 0);
        //         // Vector3 faceDir = new Vector3(targetCamera.transform.forward.x, targetCamera.transform.forward.y, 0);
        //         if (faceDir != Vector3.zero)
        //         {
        //             transform.forward = -faceDir;
        //         }
        //         // else
        //         // {
        //         //     transform.forward = Vector3.one;
        //         // }
        //     }
        //
        // }

        private void LateUpdate()
        {
            transform.forward = new Vector3(Camera.main.transform.forward.x, transform.forward.y, Camera.main.transform.forward.z);
        }
    }
}
