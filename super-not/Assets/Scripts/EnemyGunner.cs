using UnityEngine;

public class EnemyGunner : EnemyBase
{
    public Transform playerHead;
    public float attackRange = 5;
    public FireBullet gun;
    private Quaternion localRotationGun;

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
            animator.SetBool("Shoot", true);
        }
        else
        {
            agent.isStopped = false;
            animator.SetBool("Shoot", false);
        }

        Debug.DrawLine(transform.position, playerTarget.position, Color.red);
    }

    public void ShootEnemy()
    {
        var playerHeadPosition = playerHead.position - Random.Range(0, 0.04f) * Vector3.up;
        gun.spawnpoint.forward = (playerHeadPosition - gun.spawnpoint.position).normalized;
        gun.Fire();
    }

    public override void Dead(Vector3 position)
    {
        base.Dead(position);
        ThrowGun();
    }

    private void ThrowGun()
    {
        gun.spawnpoint.localRotation = localRotationGun;
        gun.transform.parent = null;
        var rb = gun.GetComponent<Rigidbody>();
        rb.velocity = BallisticVelocityVector(gun.transform.position, playerHead.position, 45);
        rb.angularVelocity = Vector3.zero;
    }

    private Vector3 BallisticVelocityVector(Vector3 source, Vector3 target, float angle)
    {
        Vector3 direction = target - source;
        float h = direction.y;
        direction.y = 0;
        float distance = direction.magnitude;
        float a = angle * Mathf.Deg2Rad;
        direction.y = distance * Mathf.Tan(a);
        distance += h / Mathf.Tan(a);

        float velocity = Mathf.Sqrt(distance * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        return velocity * direction.normalized;
    }
}
