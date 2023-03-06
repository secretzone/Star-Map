using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowFromUI : MonoBehaviour
{
    public Transform other;

    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = camera.WorldToScreenPoint(other.position);
    }
}
