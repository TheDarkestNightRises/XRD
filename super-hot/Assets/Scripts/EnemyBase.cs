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
    protected Transform playerTarget;
    public UnityEvent onDeath;

    public virtual void Start()
    {
        isDead = false;
        playerTarget = GameObject.FindWithTag("MainCamera").transform;
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
        if (isDead) return;
        isDead = true;
        SetKinematic(false);
        animator.enabled = false;
        agent.enabled = false;
        this.enabled = false;
        Debug.Log("I died");
        onDeath.Invoke();
    }
}
