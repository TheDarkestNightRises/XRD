using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] public GameObject hitParticlePrefab;
    protected Transform playerTarget;
    private GameManager gameManager;

    public bool isDead;
    protected NavMeshAgent agent;
    protected Animator animator;

    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
        SetKinematic(true);
    }

    public virtual void Dead(Vector3 hitPosition)
    {
        if (isDead) return;

        isDead = true;
        gameManager.OnEnemyDied();
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
