using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets;

public class ClimbScript : MonoBehaviour
{
    [SerializeField]
    Rigidbody playerRigidBody;

    RaycastHit topHit;
    RaycastHit botHit;
    RaycastHit groundHit;
    [SerializeField]
    float rayLength = 0.2f;


    Vector3 topRayOrigin;
    Vector3 botRayOrigin;

    [SerializeField]
    float climbSpeed;

    bool canClimb;

    private void FixedUpdate()
    {
        topRayOrigin = new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z);
        Debug.DrawRay(topRayOrigin, transform.TransformDirection(Vector3.forward) * rayLength, Color.yellow);
        botRayOrigin = new Vector3(transform.position.x, transform.position.y - 3f, transform.position.z);
        Debug.DrawRay(botRayOrigin, transform.TransformDirection(Vector3.forward) * rayLength, Color.blue);
        // if topRay is false and botRay is true

        if (!(Physics.Raycast(topRayOrigin, transform.TransformDirection(Vector3.forward), out topHit, rayLength)) && (Physics.Raycast(botRayOrigin, transform.TransformDirection(Vector3.forward), out botHit, rayLength)))
        {
            // if grounded
            if (canClimb == true && !(Physics.Raycast(botRayOrigin, transform.TransformDirection(Vector3.down), out groundHit, 4)))
            {
                canClimb = false;
                if (Input.GetButton("Jump"))
                {
                    playerRigidBody.velocity = new Vector3(playerRigidBody.velocity.x, playerRigidBody.velocity.y + climbSpeed, playerRigidBody.velocity.z);
                }               
            }
            //playerRigidBody.AddForce(Vector3.up * climbSpeed);
        }

        // else if grounded ray is true, canClimb bool = true
        else if (Physics.Raycast(botRayOrigin, transform.TransformDirection(Vector3.down), out groundHit, rayLength))
        {
            canClimb = true;
        }
    }
 
}
