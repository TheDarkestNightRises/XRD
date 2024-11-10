using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBruiser : EnemyBase
{
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float punchRange = 2f;
    [SerializeField] float attackCooldown = 1.5f;
    [SerializeField] float turnSpeed = 5f;
    private float lastAttackTime = 0f;
    private float distanceToPlayer = Mathf.Infinity;
    private bool isProvoked = false;

    public void Update()
    {
        if (isDead)
        {
            enabled = false;
            agent.enabled = false;
            return;
        }

        distanceToPlayer = Vector3.Distance(playerTarget.position, transform.position);

        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToPlayer <= chaseRange)
        {
            isProvoked = true;
        }
    }

    private void EngageTarget()
    {
        FaceTarget();

        if (distanceToPlayer >= agent.stoppingDistance && distanceToPlayer > punchRange)
        {
            ChaseTarget();
        }
        else if (distanceToPlayer <= punchRange)
        {
            agent.isStopped = true;
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                Punch();
                lastAttackTime = Time.time;
            }
        }
    }

    private void Punch()
    {
        animator.SetBool("Punch", true);
    }

    private void ChaseTarget()
    {
        animator.SetBool("Punch", false);
        if (agent.enabled)
        {
            agent.isStopped = false;
            agent.SetDestination(playerTarget.position);
            animator.SetBool("Move", true);
        }
    }

    private void FaceTarget()
    {
        Vector3 direction = (playerTarget.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, punchRange);
    }

    public override void Dead(Vector3 hitPosition)
    {
        base.Dead(hitPosition);
    }
}
