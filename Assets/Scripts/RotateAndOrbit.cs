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

    // void Rotate()
    // {
    //     float horizontal = Input.GetAxisRaw("Horizontal");
    //     float deltaTime = Time.deltaTime;
    //     Vector3 O = target.position;
    //     Vector3 P = transform.position;
    //     Vector3 R = P - O;
    //     float r = Mathf.Clamp(
    //         Vector3.Magnitude(R) - ( horizontal*orbitSpeed*deltaTime ) ,
    //         _rMin , _rMax
    //     );
    //     float c = 2f*Mathf.PI * r;
    //     float angle = ( _tangentialSpeed*deltaTime / c ) * 360f;
    //     Quaternion rot = Quaternion.AngleAxis( angle , Vector3.up );
    //
    //     transform.position = O + ( rot * Vector3.Normalize(R) * r );
    // }
}