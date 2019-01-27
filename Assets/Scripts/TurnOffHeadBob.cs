using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class TurnOffHeadBob : MonoBehaviour
{
    private float storedBobRange;

    private void OnCollisionEnter (Collision collision)
    {
        if (collision.rigidbody.tag == "Player")
        {
            HeadBob hBob = collision.rigidbody.GetComponentInChildren<HeadBob> ();
            if (hBob)
            {
                storedBobRange = hBob.motionBob.VerticalBobRange;
                hBob.motionBob.VerticalBobRange = 0f;
            }
        }
    }


    private void OnCollisionExit (Collision collision)
    {
        if (collision.rigidbody.tag == "Player")
        {
            HeadBob hBob = collision.rigidbody.GetComponentInChildren<HeadBob> ();
            if (hBob)
            {
                hBob.motionBob.VerticalBobRange = storedBobRange;
            }
        }
    }
}
