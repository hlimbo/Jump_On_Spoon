using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Ellie : MonoBehaviour
{
    Animator anim;
    const string RUNNING = "Running";
    const string WALKING = "Walking";
    private RigidbodyFirstPersonController rpfc;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rpfc = GetComponentInParent<RigidbodyFirstPersonController>();

    }

    void Update()
    {
        anim.SetBool(WALKING, (rpfc.Velocity.sqrMagnitude > 0f));
        anim.SetBool(RUNNING, rpfc.Running);
    }
}
