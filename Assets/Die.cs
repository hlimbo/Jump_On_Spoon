using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Die : MonoBehaviour
{
    public float dieVelocity = 35f;
    private float v;
    private RigidbodyFirstPersonController rfpc;
    private Rigidbody rb;
    public GameOverManager canvas;
    private bool respawned = false;

    private void Awake()
    {
        rfpc = GetComponent<RigidbodyFirstPersonController>();
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        canvas.gameObject.SetActive(false);
        Button butt = canvas.GetComponentInChildren<Button> ();
        butt.onClick.AddListener (() =>
        {
            Spawn ();
        });
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(v < -35f && !collision.gameObject.CompareTag("Soft"))
        {
            die();
            StartCoroutine (WaitForReturn ());
        }
        v = 0;
    }

    IEnumerator WaitForReturn ()
    {
        respawned = false;
        while (!respawned)
        {
            if (Input.GetKeyDown (KeyCode.Return))
            {
                Spawn ();
                yield break;
            }
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other) {
        print("HIt Trig" + other.name);
        if (other.gameObject.CompareTag("Killer"))
        {
            die();
        }
    }

    public void die()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        canvas.gameObject.SetActive(true);
    }

    public void Spawn()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        respawned = true;
        SpawnPoint.Respawn(transform);
        canvas.gameObject.SetActive(false);
    }
}
