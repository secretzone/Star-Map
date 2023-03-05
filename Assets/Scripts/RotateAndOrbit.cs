using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RotateAndOrbit : MonoBehaviour {

    public float rotationSpeed = 100f;
    public float orbitSpeed = 50f;
    public float desiredMoonDistance;
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
        transform.Rotate(dir, rotationSpeed * Time.deltaTime);
        transform.RotateAround(target.position, dir, orbitSpeed * Time.deltaTime);

        //fix possible changes in distance
        float currentMoonDistance = Vector3.Distance(target.position, transform.position);
        Vector3 towardsTarget = transform.position - target.position;
        transform.position += (desiredMoonDistance - currentMoonDistance) * towardsTarget.normalized;
    }
}