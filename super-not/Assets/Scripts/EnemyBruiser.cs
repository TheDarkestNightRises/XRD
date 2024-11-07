using UnityEngine;

public class EnemyBruiser : EnemyBase
{
    public float punchRange = 2.0f;
    public float attackCooldown = 1.5f;
    private float lastAttackTime = 0;

    public override void Update()
    {
        agent.SetDestination(playerTarget.position);
        float distance = Vector3.Distance(playerTarget.position, transform.position);

        if (distance <= punchRange)
        {
            agent.isStopped = true;
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                Punch();
                lastAttackTime = Time.time;
            }
        }
        else
        {
            agent.isStopped = false;
            animator.SetBool("Punch", false);
        }

        Debug.DrawLine(transform.position, playerTarget.position, Color.red);
    }

    private void Punch()
    {
        animator.SetTrigger("Punch");
    }
}
