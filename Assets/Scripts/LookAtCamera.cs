using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Camera targetCamera;
    void Update()
    {
        Vector3 faceDir = new Vector3(targetCamera.transform.forward.x, targetCamera.transform.forward.y, 0);
        if (targetCamera != null) transform.forward = -faceDir;
    }
}
