using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResettableTransform : Resettable
{
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    public void Awake()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    public override void ResetHandler()
    {
        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }
}
