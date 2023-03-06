using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Camera targetCamera;
    void Update()
    {
        if (targetCamera != null) transform.forward = -targetCamera.transform.forward;
    }
}
