using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBullet : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnpoint;
    public float speed = 20f;
    void Start()
    {
        var grab = GetComponent<XRGrabInteractable>();
        grab.activated.AddListener(Fire);
    }

    void Update()
    {
        
    }

    public void Fire(ActivateEventArgs arg)
    {
        var spawnBullet = Instantiate(bullet);
        spawnBullet.transform.position = spawnBullet.transform.position;
        spawnBullet.GetComponent<Rigidbody>().velocity = spawnpoint.forward * speed;
        Destroy(spawnBullet,5);
    }
}
