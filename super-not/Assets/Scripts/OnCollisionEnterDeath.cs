using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionEnterDeath : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var death = other.GetComponent<EnemyOnCollision>();
        if (death is null) return;
        death.enemy.Dead(transform.position);
    }
}
