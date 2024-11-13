using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public string targetTag;
    public UnityEvent onPlayerDeath;
    public bool IsDead { get; set; }

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
