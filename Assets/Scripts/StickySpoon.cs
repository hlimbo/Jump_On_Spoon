using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class StickySpoon : MonoBehaviour
{
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

    private IEnumerator HandleInput (RigidbodyFirstPersonController rfpc)
    {
        body.isKinematic = true;
        body.velocity = Vector3.zero;
        body.angularVelocity = Vector3.zero;
        body.transform.SetParent (transform);

        while (body)
        {
            rfpc.OverrideUpdate ();

            yield return null;
        }
    }
}
