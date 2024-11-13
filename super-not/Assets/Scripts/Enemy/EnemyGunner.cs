using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyGunner : EnemyBase
{
    public FireBullet gun;
    [SerializeField] private float attackRange = 5;
    [SerializeField] private float turnSpeed = 5;
    private Transform playerHead;

    private Quaternion localRotationGun;

    protected override void Start()
    {
        base.Start();
        playerHead = GameObject.FindGameObjectWithTag("MainCamera").transform;
        localRotationGun = gun.spawnpoint.localRotation;
    }

    public void Update()
    {
        agent.SetDestination(playerTarget.position);

        float distance = Vector3.Distance(playerTarget.position, transform.position);

        if (distance < attackRange)
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
    }

    public void ThrowGun()
    {
        gun.spawnpoint.localRotation = localRotationGun;

        gun.transform.parent = null;
        Rigidbody rb = gun.GetComponent<Rigidbody>();
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

    public void ShootEnemy()
    {
        Vector3 playerHeadPosition = playerHead.position - Random.Range(0, 0.4f) * Vector3.up;

        gun.spawnpoint.forward = (playerHeadPosition - gun.spawnpoint.position).normalized;

        gun.Fire();
    }

    private void FaceTarget()
    {
        Vector3 direction = (playerTarget.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    public override void Dead(Vector3 hitPosition)
    {
        base.Dead(hitPosition);
        ThrowGun();
    }
}
