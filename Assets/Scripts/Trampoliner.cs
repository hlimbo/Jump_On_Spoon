using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Trampoliner : MonoBehaviour
{
    public float[] jumpSpeeds = new float[0];
    public float jumpDrag = 2f;
    public float airSpeed = 1f;

    [SerializeField]
    public Trampoline oldTramp;
    [SerializeField]
    private int bounces = 0;
    private RigidbodyFirstPersonController rfpc;

    private void Awake ()
    {
        rfpc = GetComponent<RigidbodyFirstPersonController> ();
        if (!rfpc) Debug.LogError ("no rfpc!");
    }

    private void OnCollisionEnter (Collision collision)
    {
        Trampoline collidedTramp = collision.gameObject.GetComponentInParent<Trampoline> ();
        if (collidedTramp) 
        {
            print("hit tramp!");
            if (oldTramp)
            {
                // Player is bouncing again!
                bounces++;
                if (bounces > jumpSpeeds.Length)
                {
                    bounces = jumpSpeeds.Length;
                }
            }
            else
            {
                bounces = 1;
                oldTramp = collidedTramp;
            }

            rfpc.OverrideJump (jumpSpeeds[bounces - 1], jumpDrag);
            rfpc.trampolining = true;

            rfpc.movementSettings.ForwardSpeed = airSpeed;
            rfpc.movementSettings.BackwardSpeed = airSpeed;
            rfpc.movementSettings.StrafeSpeed = airSpeed;
        }
        else
        {
            print(collision.gameObject + " hit non tramp" );
            rfpc.movementSettings.ForwardSpeed = 8f;
            rfpc.movementSettings.BackwardSpeed = 4f;
            rfpc.movementSettings.StrafeSpeed = 4f;

            rfpc.trampolining = false;
            bounces = 0;
            oldTramp = null;
        }
    }
}
