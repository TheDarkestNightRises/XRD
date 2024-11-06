using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnCollision : MonoBehaviour
{
    public Enemy enemy;
    public string targetTag;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == targetTag)
        {
            enemy.Dead(collision.contacts[0].point);
        }
    }
}
