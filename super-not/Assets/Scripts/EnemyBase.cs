using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public abstract class EnemyBase : MonoBehaviour
{
    public bool isDead;
    public GameObject hitParticlePrefab;
    protected NavMeshAgent agent;
    protected Animator animator;
    public Transform playerTarget;
    public UnityEvent onDeath;

    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        SetKinematic(true);
    }

    public virtual void Dead(Vector3 hitPosition)
    {
        if (isDead) return;

        isDead = true;
        onDeath.Invoke();
        EnableRagdoll(hitPosition);
        animator.enabled = false;
        agent.enabled = false;
        this.enabled = false;
    }

    protected void EnableRagdoll(Vector3 hitPosition)
    {
        SetKinematic(false);

        foreach (var item in Physics.OverlapSphere(hitPosition, 0.3f))
        {
            Rigidbody rb = item.GetComponent<Rigidbody>();
            if (rb)
            {
                rb.AddExplosionForce(1000, hitPosition, 0.3f);
            }
        }
    }

    private void SetKinematic(bool kinematic)
    {
        foreach (var item in GetComponentsInChildren<Rigidbody>())
        {
            item.isKinematic = kinematic;
        }
    }
}
