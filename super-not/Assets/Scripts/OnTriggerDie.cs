using UnityEngine;

public class OnTriggerDie : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var death = other.GetComponent<EnemyOnCollision>();
        if (death is null) return;
        death.enemy.Dead(transform.position);
    }
}
