using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResettablePosition : Resettable
{
    private Vector3 originalPosition;

    public void Awake()
    {
        originalPosition = transform.position;
    }

    public override void ResetHandler()
    {
        transform.position = originalPosition; 
    }
}