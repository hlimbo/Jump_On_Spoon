﻿using System.Collections;
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
                if (bounces > oldTramp.jumpSpeeds.Length) //jumpSpeeds.Length)
                {
                    bounces = oldTramp.jumpSpeeds.Length; // jumpSpeeds.Length;
                }
            }
            else
            {
                bounces = 1;
                oldTramp = collidedTramp;
            }

            rfpc.OverrideJump (oldTramp.jumpSpeeds[bounces - 1], jumpDrag);
            rfpc.trampolining = true;

            rfpc.movementSettings.ForwardSpeed = airSpeed;
            rfpc.movementSettings.BackwardSpeed = airSpeed;
            rfpc.movementSettings.StrafeSpeed = airSpeed;
        }
        else
        {
            rfpc.movementSettings.ForwardSpeed = 6f;
            rfpc.movementSettings.BackwardSpeed = 3f;
            rfpc.movementSettings.StrafeSpeed = 3f;

            rfpc.trampolining = false;
            bounces = 0;
            oldTramp = null;
        }
    }
}
