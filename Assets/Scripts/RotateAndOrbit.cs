using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Serialization;

public class RotateAndOrbit : MonoBehaviour {
    
    [Tooltip("Degrees per frame to rotate")]
    public float orbitSpeed = 0.001f;
    
    [Tooltip("Distance from target transform")]
    public float distance;
    
    [Tooltip("The transform to rotate around")]
    public Transform target;
    
    [Tooltip("This transform will always 'look at' the target")]
    public Transform rotationReference;

    void Start ()
    {
        if (target == null)
        {
            target = transform.parent; 
        }
        //desiredMoonDistance = Vector3.Distance(target.position, transform.position);
    }

    void Update () {
        Vector3 dir = Vector3.forward;
        
        float step = (orbitSpeed / distance) * 360;
        
        // transform.Rotate(dir, rotationSpeed * Time.deltaTime);
        rotationReference.LookAt(target.position); 
        transform.RotateAround(target.position, dir, step * Time.deltaTime);
        
        //fix possible changes in distance
        float currentMoonDistance = Vector3.Distance(target.position, transform.position);
        Vector3 towardsTarget = transform.position - target.position;
        transform.position += (distance - currentMoonDistance) * towardsTarget.normalized;
        // transform.LookAt(target.transform);
    }

}