using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingUpdateComponent : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 moveDirection;
    [Tooltip("Time in seconds unit moves in one direction")]
    public float paceFrequency;

    private Rigidbody rb;
    [SerializeField]
    private Vector3 currentMoveDirection;
    [SerializeField]
    private float startTime;

    void Start()
    {
        currentMoveDirection = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);
        rb = GetComponent<Rigidbody>();
        // StartCoroutine(Patrol());
        startTime = Time.time;
    }

    private void Update()
    {
        float deltaTime = Time.time - startTime;
        if (deltaTime < paceFrequency)
        {
            rb.MovePosition(transform.position + (currentMoveDirection * moveSpeed * Time.deltaTime));
            deltaTime = Time.time - startTime;
        }
        else
        {
            currentMoveDirection = currentMoveDirection * -1.0f;
            startTime = Time.time;
        }
    }
}
