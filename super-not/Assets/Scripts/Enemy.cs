using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform playerTarget;

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetUpRag();    
    }

    public void Update()
    {
        agent.SetDestination(playerTarget.position);
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
