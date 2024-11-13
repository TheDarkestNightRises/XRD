using UnityEngine;
using UnityEngine.AI;

public class ResettableEnemyGunner : Resettable
{
    private EnemyGunner enemyGunner;
    private Animator animator;
    private NavMeshAgent agent;

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Quaternion originalGunRotation;

    private void Awake()
    {
        enemyGunner = GetComponent<EnemyGunner>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        originalPosition = transform.position;
        originalRotation = transform.rotation;
        originalGunRotation = enemyGunner.gun.spawnpoint.localRotation;

        SetRagdollKinematic(true);
    }

    public override void ResetHandler()
    {
        transform.position = originalPosition;
        transform.rotation = originalRotation;

        enemyGunner.gun.transform.SetParent(transform); 
        enemyGunner.gun.spawnpoint.localRotation = originalGunRotation;

        gameObject.SetActive(true);
        SetRagdollKinematic(true); 
        animator.enabled = true;
        agent.enabled = true;

        enemyGunner.isDead = false; 
        animator.SetBool("Shoot", false); 
    }

    private void SetRagdollKinematic(bool kinematic)
    {
        foreach (var rb in GetComponentsInChildren<Rigidbody>())
        {
            rb.isKinematic = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = kinematic;
        }
    }
}
