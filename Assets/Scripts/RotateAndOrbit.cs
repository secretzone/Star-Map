using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RotateAndOrbit : MonoBehaviour {

    public float rotationSpeed = 100f;
    public float orbitSpeed = 50f;
    [FormerlySerializedAs("desiredMoonDistance")] public float distance;
    public Transform target;

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
        
        transform.Rotate(dir, rotationSpeed * Time.deltaTime);
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