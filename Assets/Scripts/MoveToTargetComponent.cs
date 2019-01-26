using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTargetComponent : MonoBehaviour
{
    public float moveSpeed;
    public float stoppingDistance;
    public GameObject target;
    private Vector3 targetDirection;
    private Vector3 distance;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // subtract current position by target position and normalize it
        distance = target.transform.position - transform.position;
        if (distance.magnitude > stoppingDistance)
        {
            targetDirection = Vector3.Normalize(distance);
            rb.MovePosition(transform.position + (targetDirection * moveSpeed * Time.deltaTime));
        }
    }
}
