﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Die : MonoBehaviour
{
    public float dieVelocity = 35f;
    private float v;
    private RigidbodyFirstPersonController rfpc;
    private Rigidbody rb;
    private Canvas canvas;

    private void Awake()
    {
        rfpc = GetComponent<RigidbodyFirstPersonController>();
        rb = GetComponent<Rigidbody>();
        canvas = FindObjectOfType<Canvas>();
    }

    private void Start()
    {
        canvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (rfpc.Grounded && v < -dieVelocity)
        {
            canvas.gameObject.SetActive(true);
        }
        v = rb.velocity.y;
    }

    public void Spawn()
    {
        SpawnPoint.Respawn(transform);
        canvas.gameObject.SetActive(false);
    }
}
