using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResettableBodyPart : Resettable
{
    private BodyPartScript bodyPartScript;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Vector3 originalScale;

    void Awake()
    {
        // Store the original position, rotation, and scale of the body part
        bodyPartScript = GetComponent<BodyPartScript>();
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        originalScale = transform.localScale;
    }

    public override void ResetHandler()
    {
        // Deactivate the GameObject to reset it
        gameObject.SetActive(false);

        // Reactivate the GameObject
        gameObject.SetActive(true);

        // Reset the position, rotation, and scale to their original values
        transform.position = originalPosition;
        transform.rotation = originalRotation;
        transform.localScale = originalScale;

        // Reset other values like Rigidbody state and replacement flag
        bodyPartScript.replaced = false;
        bodyPartScript.rb.isKinematic = true;
    }
}
