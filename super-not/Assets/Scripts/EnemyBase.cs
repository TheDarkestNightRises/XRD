using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyBase : MonoBehaviour
{
    protected NavMeshAgent agent;
    protected Animator animator;
    public Transform playerTarget;

    public virtual void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        SetUpRag();
    }

    public abstract void Update();

    public void SetKinematic(bool kinematic)
    {
        foreach (var item in GetComponentsInChildren<Rigidbody>())
        {
            item.isKinematic = kinematic;
        }
    }

    public void SetUpRag()
    {
        SetKinematic(true);
    }

    public virtual void Dead(Vector3 position)
    {
        SetKinematic(false);

        foreach (var item in Physics.OverlapSphere(position, 0.3f))
        {
            var rb = item.GetComponent<Rigidbody>();
            if (rb)
            {
                rb.AddExplosionForce(1000, position, 0.3f);
            }
        }

        animator.enabled = false;
        agent.enabled = false;
        this.enabled = false;
    }
}
