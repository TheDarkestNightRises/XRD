using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerKillPlayer : MonoBehaviour
{
    [SerializeField] private string playerTag = "XR"; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            Player player = other.GetComponent<Player>();

            if (player != null && !player.IsDead)
            {
                player.Die();
            }
        }
    }

}
