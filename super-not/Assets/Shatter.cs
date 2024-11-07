using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatter : MonoBehaviour
{
    public GameObject shatteredObject;
    public float explosionForce = 300f;
    public float explosionRadius = 1.5f;
    public Vector3 explosionOffset = Vector3.zero;

    private bool hasShattered = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (hasShattered) return;
        hasShattered = true;

        gameObject.SetActive(false);

        GameObject shatteredInstance = Instantiate(shatteredObject, transform.position, transform.rotation);

        foreach (Rigidbody rb in shatteredInstance.GetComponentsInChildren<Rigidbody>())
        {
            rb.AddExplosionForce(explosionForce, transform.position + explosionOffset, explosionRadius);
        }

        Destroy(shatteredInstance, 5f);
    }
}
