using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.FirstPerson;

public class TowelElevator : MonoBehaviour
{
    public float climbSpeed = 25f;

    private Rigidbody body;


    private void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            RigidbodyFirstPersonController rfpc = other.GetComponentInChildren<RigidbodyFirstPersonController> ();
            rfpc.enabled = false;
            body = other.GetComponent<Rigidbody> ();
            StartCoroutine (HandleInput (rfpc));
        }
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.tag == "Player")
        {
            RigidbodyFirstPersonController rfpc = other.GetComponentInChildren<RigidbodyFirstPersonController> ();
            rfpc.enabled = true;
            body.isKinematic = false;
            body = null;
        }
    }

    private IEnumerator HandleInput (RigidbodyFirstPersonController rfpc)
    {
        body.isKinematic = true;
        body.velocity = Vector3.zero;
        body.angularVelocity = Vector3.zero;

        while (body)
        {
            rfpc.OverrideUpdate ();

            if (Input.GetAxis ("Vertical") > 0)
            {
                body.transform.position += (Vector3.up * climbSpeed * Time.deltaTime);
            }
            else if (Input.GetAxis ("Vertical") < 0)
            {
                body.transform.position += (-Vector3.up * climbSpeed * Time.deltaTime);
            }

            yield return null;
        }
    }
}
