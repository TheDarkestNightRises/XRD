using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] public GameObject hitParticlePrefab;
    [SerializeField] protected Transform playerTarget;
    [HideInInspector] public UnityEvent onDeath;
    public bool isDead;
    protected NavMeshAgent agent;
    protected Animator animator;

    protected virtual void Start()
    {
        playerTarget = GameObject.FindGameObjectWithTag("MainCamera").transform;
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
