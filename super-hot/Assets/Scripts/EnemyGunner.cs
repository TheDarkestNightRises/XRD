using UnityEngine;

public class EnemyGunner : EnemyBase
{
    public Transform playerHead;
    public float attackRange = 5;
    public FireBullet gun;
    private Quaternion localRotationGun;
    public float turnSpeed = 5f; 

    public override void Start()
    {
        base.Start();
        localRotationGun = gun.spawnpoint.localRotation;
    }

    public override void Update()
    {
        agent.SetDestination(playerTarget.position);
        float distance = Vector3.Distance(playerTarget.position, transform.position);

        if (distance <= attackRange)
        {
            agent.isStopped = true;
            FaceTarget();
            animator.SetBool("Shoot", true);
        }
        else
        {
            agent.isStopped = false;
            animator.SetBool("Shoot", false);
        }

        Debug.DrawLine(transform.position, playerTarget.position, Color.red);
    }

    private void FaceTarget()
    {
        Vector3 direction = (playerTarget.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    public void ShootEnemy()
    {
        var playerHeadPosition = playerHead.position - Random.Range(0, 0.04f) * Vector3.up;
        gun.spawnpoint.forward = (playerHeadPosition - gun.spawnpoint.position).normalized;
        gun.Fire();
    }

    public override void Dead(Vector3 position)
    {
        if (isDead) return;
        ThrowGun();
        base.Dead(position);
    }

    private void ThrowGun()
    {
        gun.spawnpoint.localRotation = localRotationGun;
        gun.transform.parent = null;
        var rb = gun.GetComponent<Rigidbody>();
        rb.velocity = BallisticVelocityVector(gun.transform.position, playerHead.position, 45);
        rb.angularVelocity = Vector3.zero;
    }

    Vector3 BallisticVelocityVector(Vector3 startPoint, Vector3 targetPoint, float angle)
    {
        Vector3 direction = targetPoint - startPoint;
        float heightDifference = direction.y;
        direction.y = 0;
        float distance = direction.magnitude;
        float angleRad = angle * Mathf.Deg2Rad;

        float velocitySquared = (Physics.gravity.magnitude * distance * distance) /
                                (2 * (distance * Mathf.Tan(angleRad) - heightDifference));

        if (velocitySquared <= 0)
        {
            Debug.LogError("Invalid ballistic calculation, returning zero vector");
            return Vector3.zero;
        }

        float velocity = Mathf.Sqrt(velocitySquared);

        Vector3 velocityVector = direction.normalized;
        velocityVector *= velocity * Mathf.Cos(angleRad);
        velocityVector.y = velocity * Mathf.Sin(angleRad);

        return velocityVector;
    }
}
