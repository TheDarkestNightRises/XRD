using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBullet : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnpoint;
    public float speed = 20f;
    public AudioSource source;
    public AudioClip clip;
    public ParticleSystem muzzleFlash;

    void Start()
    {
        var grab = GetComponent<XRGrabInteractable>();
        grab.activated.AddListener(Fire);
    }

    public void Fire(ActivateEventArgs arg = null)
    {
        var spawnBullet = Instantiate(bullet);
        spawnBullet.transform.rotation = spawnpoint.rotation;
        spawnBullet.transform.position = spawnpoint.transform.position;
        spawnBullet.GetComponent<Rigidbody>().velocity = spawnpoint.forward * speed;
        Destroy(spawnBullet,5);
        source.PlayOneShot(clip);
        muzzleFlash.Play();
    }
}
