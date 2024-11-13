using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ResettablePlayer : Resettable
{
    private Player player;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Transform xrOriginTransform;

    private void Awake()
    {
        player = GetComponent<Player>();
        xrOriginTransform = transform; 
        originalPosition = xrOriginTransform.position;
        originalRotation = xrOriginTransform.rotation;
    }

    public override void ResetHandler()
    {
        xrOriginTransform.position = originalPosition;
        xrOriginTransform.rotation = originalRotation;

        player.IsDead = false;

        RecenterTrackingOrigin();
    }

    private void RecenterTrackingOrigin()
    {
        // Access the XR Input Subsystem and recenter
        List<XRInputSubsystem> xrInputSubsystems = new List<XRInputSubsystem>();
        SubsystemManager.GetInstances(xrInputSubsystems);

        foreach (var xrInputSubsystem in xrInputSubsystems)
        {
            xrInputSubsystem.TryRecenter();
        }
    }
}
