﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartScript : MonoBehaviour
{
    public EnemyBase enemy;
    public Renderer bodyPartRenderer;
    public GameObject bodyPartPrefab;
    private Rigidbody rb;
    private bool replaced;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void HidePartAndReplace()
    {
        if (replaced)
            return;

        if(bodyPartRenderer!=null)
        bodyPartRenderer.enabled = false;

        GameObject part = new GameObject();
        if (bodyPartPrefab !=null)
        part = Instantiate(bodyPartPrefab, transform.position, transform.rotation);

        Rigidbody[] rbs = part.GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody r in rbs)
        {
            r.interpolation = RigidbodyInterpolation.Interpolate;
            r.AddExplosionForce(15, transform.position, 5);
        }

        rb.AddExplosionForce(15, transform.position, 5);

        this.enabled = false;
        replaced = true;
    }
}