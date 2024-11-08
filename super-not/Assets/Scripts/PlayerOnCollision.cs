using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerOnCollision : MonoBehaviour
{
    public string targetTag;
    public UnityEvent onPlayerDeath;
    public bool IsDead { get; private set; }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == targetTag)
        {
            Die();
        }
    }

    public void Die()
    {
        if (IsDead) return;
        IsDead = true;
        onPlayerDeath?.Invoke();
    }
}
