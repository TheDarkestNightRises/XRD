using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnCollision : MonoBehaviour
{
    public EnemyBase enemy;
    public string targetTag;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == targetTag)
        {
            BodyPartScript bp = this.gameObject.GetComponent<BodyPartScript>();
            Instantiate(enemy.hitParticlePrefab, transform.position, transform.rotation);
            bp.HidePartAndReplace();
            enemy.Dead(collision.contacts[0].point);
        }
    }
}
