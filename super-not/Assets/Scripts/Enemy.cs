using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform playerTarget;
    private Animator animator;
    public float attackRange = 5;
    public FireBullet gun;

    public void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        SetUpRag();    
    }

    public void Update()
    {
        agent.SetDestination(playerTarget.position);
        float distance = Vector3.Distance(playerTarget.position, transform.position);

        if (distance > attackRange)
        {
            agent.isStopped = true;
            animator.SetBool("Shoot", true);
        }

        Debug.DrawLine(transform.position, playerTarget.position, Color.red);
    }

    public void ShootEnemy()
    {
        gun.Fire();
    }

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

    public void Dead(Vector3 position)
    {
        SetKinematic(false);

        foreach(var item in Physics.OverlapSphere(position, 0.3f))
        {
            var rb = item.GetComponent<Rigidbody>();
            if (rb)
            {
                rb.AddExplosionForce(1000, position, 0.3f);
            }
        }
    }
}
