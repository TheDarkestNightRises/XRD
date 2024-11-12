using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AK47Fire : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnpoint;
    public float speed = 20f;
    public AudioSource source;
    public AudioClip clip;
    public ParticleSystem muzzleFlash;

    private XRGrabInteractable grab;
    private bool isFiring = false;
    public float fireRate = 0.1f; 
    private float lastFiredTime = 0f;

    void Start()
    {
        grab = GetComponent<XRGrabInteractable>();
        grab.activated.AddListener(OnActivate);
        grab.deactivated.AddListener(OnDeactivate);
    }

    void Update()
    {
        if (isFiring && Time.time - lastFiredTime >= fireRate)
        {
            Fire();
        }
    }

    private void OnActivate(ActivateEventArgs arg)
    {
        isFiring = true;
    }

    private void OnDeactivate(DeactivateEventArgs arg)
    {
        isFiring = false;
    }

    public void Fire()
    {

        lastFiredTime = Time.time;

        var spawnBullet = Instantiate(bullet);
        spawnBullet.transform.position = spawnpoint.position;
        spawnBullet.GetComponent<Rigidbody>().velocity = spawnpoint.forward * speed;

        Destroy(spawnBullet, 5f);

        source.PlayOneShot(clip);
        muzzleFlash.Stop();
        muzzleFlash.Play();
    }
}