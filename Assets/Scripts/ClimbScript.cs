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
    private Rigidbody _PlayerRigidBody;
    [SerializeField]
    private Transform _ClimbReference;
    [SerializeField]
    private float _RayLength = 0.2f;
    [SerializeField]
    [Range(0, 1)]
    private float _LerpRate;
    [SerializeField]
    private float _LerpPositionToOffset;

    private RaycastHit _ClimbReferenceHit;
    private RaycastHit _TopHit;
    private RaycastHit _BotHit;
    private RaycastHit _GroundHit;

    private Vector3 _TopRayOrigin;
    private Vector3 _BotRayOrigin;

    bool canClimb = true;

    private void FixedUpdate()
    {
        //Debug.DrawRay(topRayOrigin, transform.TransformDirection(Vector3.forward) * rayLength, Color.yellow);
        //topRayOrigin = new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z);
        //Debug.DrawRay(topRayOrigin, transform.TransformDirection(Vector3.forward) * rayLength, Color.yellow);
        _BotRayOrigin = new Vector3(transform.position.x, transform.position.y - 3f, transform.position.z);
        //Debug.DrawRay(botRayOrigin, transform.TransformDirection(Vector3.forward) * rayLength, Color.blue);
        // if topRay is false and botRay is true

        Debug.DrawRay(_ClimbReference.position, Vector3.down * _RayLength, Color.red);
        if (Physics.Raycast(_ClimbReference.position, Vector3.down, out _ClimbReferenceHit, _RayLength))
            //(!(Physics.Raycast(topRayOrigin, transform.TransformDirection(Vector3.forward), out topHit, rayLength)) &&
            //    (Physics.Raycast(botRayOrigin, transform.TransformDirection(Vector3.forward), out botHit, rayLength)
        {
            // if grounded
            if (canClimb == true /*&& !(Physics.Raycast(botRayOrigin, transform.TransformDirection(Vector3.down), out groundHit, 4))*/)
            {
                print("canClimb was true");
                if (Input.GetButtonDown("Jump"))
                {
                    //canClimb = false;
                    Vector3 startingPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    Vector3 endPos = new Vector3(transform.position.x, _ClimbReferenceHit.point.y + _LerpPositionToOffset, transform.position.z);
                    print("climbing");
                    StartCoroutine(LerpToPoint(startingPos, endPos));
                    //transform.position = new Vector3(transform.position.x, Mathf.Lerp(startingYVel, climbReferenceHit.point.y + 4, lerpVal * Time.deltaTime), transform.position.z);
                }               
            }
        }
        // else if grounded ray is true, canClimb bool = true
        else if (Physics.Raycast(_BotRayOrigin, transform.TransformDirection(Vector3.down), out _GroundHit, _RayLength))
        {
            canClimb = true;
        }
    }

    IEnumerator LerpToPoint(Vector3 _pos1, Vector3 _pos2)
    {
        while (_pos2.y > transform.position.y)
        {
            print("pos2: " + _pos2.y);
            float i = Time.deltaTime * _LerpRate;
            transform.position = Vector3.Lerp(_pos1, _pos2, _LerpRate * Time.deltaTime);

            if (_pos2.y - 1 < transform.position.y)
                break;
        }

        yield return null;
    }
}
