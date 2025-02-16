﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public float myTimeScale = 1.0f;
    public GameObject target;
    public float launchForce = 5f;
    public AudioSource audioSource;

    Rigidbody rb;
    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        Time.timeScale = myTimeScale;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (audioSource != null)
            {
                audioSource.Play(); // play jumpSFX
            }

            FiringSolution fs = new FiringSolution();
            Nullable<Vector3> aimVector = fs.Calculate(transform.position, target.transform.position, launchForce, Physics.gravity);
            if (aimVector.HasValue)
            {
                rb.AddForce(aimVector.Value.normalized * launchForce, ForceMode.VelocityChange);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            // reset
            rb.isKinematic = true;
            transform.position = startPos;
            rb.isKinematic = false;
        }
    }
}