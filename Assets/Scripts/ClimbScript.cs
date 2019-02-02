using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets;
/// <summary>
/// Needs revisions for smooth climb-over. Could use sphere cast in middle of player for detection. 2ndly, need to move 
/// player smoothly onto surface. Could find normal of the climbable surface. Lerp player up onto that normal???
/// </summary>
public class ClimbScript : MonoBehaviour
{
    [SerializeField]
    Rigidbody playerRigidBody;
    [SerializeField]
    Transform climbReference;

    RaycastHit climbReferenceHit;
    RaycastHit topHit;
    RaycastHit botHit;
    RaycastHit groundHit;
    [SerializeField]
    float rayLength = 0.2f;

    Vector3 topRayOrigin;
    Vector3 botRayOrigin;

    [SerializeField]
    private float climbSpeed;
    [SerializeField]
    [Range ( 0, 1 )]
    private float lerpVal;

    bool canClimb;

    private void FixedUpdate()
    {
        //Debug.DrawRay(topRayOrigin, transform.TransformDirection(Vector3.forward) * rayLength, Color.yellow);
        //topRayOrigin = new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z);
        //Debug.DrawRay(topRayOrigin, transform.TransformDirection(Vector3.forward) * rayLength, Color.yellow);
        botRayOrigin = new Vector3(transform.position.x, transform.position.y - 3f, transform.position.z);
        //Debug.DrawRay(botRayOrigin, transform.TransformDirection(Vector3.forward) * rayLength, Color.blue);
        // if topRay is false and botRay is true

        Debug.DrawRay(climbReference.position, Vector3.down * rayLength, Color.red);

        if (Physics.Raycast(climbReference.position, Vector3.down, out climbReferenceHit, rayLength))
            //(!(Physics.Raycast(topRayOrigin, transform.TransformDirection(Vector3.forward), out topHit, rayLength)) &&
            //    (Physics.Raycast(botRayOrigin, transform.TransformDirection(Vector3.forward), out botHit, rayLength)
        {
            // if grounded
            if (canClimb == true /*&& !(Physics.Raycast(botRayOrigin, transform.TransformDirection(Vector3.down), out groundHit, 4))*/)
            {
                print("canClimb was true");
                canClimb = false;
                if (Input.GetButtonDown("Jump"))
                {
                    Vector3 startingPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    Vector3 endPos = new Vector3(transform.position.x, climbReferenceHit.point.y + 4, transform.position.z);
                    print("climbing");
                    StartCoroutine(LerpToPoint(startingPos, endPos));
                    //transform.position = new Vector3(transform.position.x, Mathf.Lerp(startingYVel, climbReferenceHit.point.y + 4, lerpVal * Time.deltaTime), transform.position.z);
                }               
            }
            // playerRigidBody.AddForce(Vector3.up * climbSpeed);
        }
        // else if grounded ray is true, canClimb bool = true
        else if (Physics.Raycast(botRayOrigin, transform.TransformDirection(Vector3.down), out groundHit, rayLength))
        {
            canClimb = true;
        }
    }

    IEnumerator LerpToPoint(Vector3 _pos1, Vector3 _pos2)
    {
        print("LERP");
        transform.position = Vector3.Lerp(_pos1, _pos2, lerpVal);

        yield return null;
    }
}
