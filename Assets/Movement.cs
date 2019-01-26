using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Interacts with Unity's CharacterController to control player movement
/// </summary>
public class Movement : MonoBehaviour
{
    public static Movement instance;

    [SerializeField]
    public float forwardMovement;
    [SerializeField]
    public float strafeMovement;
    [SerializeField]
    public float moveSpeed = 6.0f;
    [SerializeField]
    public float jumpSpeed = 8.0f;
    [SerializeField]
    public float gravity = 20.0f;

    [SerializeField]
    private Camera mainCamera;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    #region UNITY CALLBACKS

    private void OnEnable()
    {
        if (instance == null)
            instance = this;
    }

    private void OnDisable()
    {
        instance = null;
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // let the gameObject fall down
        gameObject.transform.position = new Vector3(0, 5, 0);
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            forwardMovement = (Input.GetAxis("Vertical")) * moveSpeed;
            strafeMovement = (Input.GetAxis("Horizontal")) * moveSpeed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }

            // We are grounded, so recalculate
            // move direction directly from axes

            //moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            //moveDirection = transform.TransformDirection(moveDirection);
            //moveDirection = moveDirection * moveSpeed;

            moveDirection = new Vector3(strafeMovement, moveDirection.y, forwardMovement);         
        }
       
        // Apply gravity
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);
 
        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);
    }
    #endregion
}

