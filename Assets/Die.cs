using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Die : MonoBehaviour
{
    public float dieVelocity = 35f;
    private float v;
    private RigidbodyFirstPersonController rfpc;
    private Rigidbody rb;
    private void Start()
    {
        rfpc = GetComponent<RigidbodyFirstPersonController>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Debug.Log(rfpc.Grounded);
        Debug.Log(v);
        if (rfpc.Grounded && v < -dieVelocity)
        {
            SpawnPoint.Respawn(transform);
        }
        v = rb.velocity.y;
    }
}
