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
        //if (rfpc.Grounded && v < -dieVelocity)
        //{
        //    canvas.gameObject.SetActive(true);
        //}
        v = rb.velocity.y < v ? rb.velocity.y : v;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(v < -35f && !collision.gameObject.CompareTag("Soft"))
        {
            die();
        }
        v = 0;

    }

    private void OnTriggerEnter(Collider other) {
        print("HIt Trig" + other.name);
        if(other.gameObject.name == "KillerRat")
        {
            print("Rat will kill me");
            die();
        }
    }

    public void die()
    {
        canvas.gameObject.SetActive(true);
    }

    public void Spawn()
    {
        SpawnPoint.Respawn(transform);
        canvas.gameObject.SetActive(false);
    }
}
