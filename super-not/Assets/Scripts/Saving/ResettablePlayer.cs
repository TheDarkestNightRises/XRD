using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class ResettablePlayer : Resettable
{
    private Player player;  
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private void Awake()
    {
        player = GetComponent<Player>();

        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    public override void ResetHandler()
    {
        transform.position = originalPosition;
        transform.rotation = originalRotation;

        // Reset the player's state
        player.IsDead = false;
        player.gameObject.SetActive(true);
    }
}
