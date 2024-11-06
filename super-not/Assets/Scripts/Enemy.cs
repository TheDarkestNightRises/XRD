using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform playerTarget;
    public Transform playerHead;
    private Animator animator;
    public float attackRange = 5;
    public FireBullet gun;
    private Quaternion localRotationGun;

    public void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        SetUpRag();    
        localRotationGun = gun.spawnpoint.localRotation;
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
        var playerHeadPosition = playerHead.position - Random.Range(0, 0.04f) * Vector3.up;
        gun.spawnpoint.forward = (playerHeadPosition - gun.spawnpoint.position).normalized;
        gun.Fire();
    }

    public void ThrowGun()
    {
        gun.spawnpoint.localRotation = localRotationGun;
        gun.transform.parent = null;
        var rb = gun.GetComponent<Rigidbody>();
        rb.velocity = BallisticVelocityVector(gun.transform.position, playerHead.position, 45);
        rb.angularVelocity = Vector3.zero;
    }

    Vector3 BallisticVelocityVector(Vector3 source, Vector3 target, float angle)
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

        ThrowGun();
        animator.enabled = false;
        agent.enabled = false;
        this.enabled = false;
    }
}
