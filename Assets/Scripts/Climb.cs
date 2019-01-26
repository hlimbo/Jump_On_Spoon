using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Player can climb up to platform in front of them if the ray shooting from the top of them doesn't hit ground
///    but the bottom ray does hit ground. 
/// </summary>
public class Climb : MonoBehaviour
{
    RaycastHit topRayHit;
    RaycastHit botRayHit;
    LayerMask groundLayer;

    private void FixedUpdate()
    {
        // Does the ray shooting from the TOP of the player hit ground. References layermask through PhysicsLayers enum. 
        if (Physics.Raycast(transform.position, transform.TransformDirection((0, 0.5, Vector3.forward.z), out topRayHit, 1f, LayerMask.layer))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * topRayHit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }

        // Deos the ray shooting from the BOTTOM of the player hit ground
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
