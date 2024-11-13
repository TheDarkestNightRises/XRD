using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResettablePosition : Resettable
{
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Rigidbody rb;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    public override void ResetHandler()
    {
        rb.useGravity = false;
        rb.velocity = Vector3.zero; 
        rb.angularVelocity = Vector3.zero; 
        transform.position = originalPosition; 
        transform.rotation = originalRotation;
    }
}