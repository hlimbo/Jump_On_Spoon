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

    private RatBrain.RatState stateRef;
    [SerializeField]
    private bool canChase = false;
    private bool hasCoroutineStarted = false;

    private bool isCloseEnough = false;
    public bool IsCloseEnough() { return isCloseEnough; }

    private Rigidbody rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private IEnumerator Chase()
    {
        while(canChase)
        {
            distance = target.transform.position - transform.position;
            isCloseEnough = distance.magnitude < stoppingDistance;
            if (distance.magnitude > stoppingDistance)
            {
                targetDirection = Vector3.Normalize(distance);
                rb.MovePosition(transform.position + (targetDirection * moveSpeed * Time.deltaTime));
            }

            yield return null;
        }
    }

    public void BeginChasing(RatBrain.RatState state, GameObject target)
    {
        stateRef = state;
        // change target if currentTarget is overwritten from SensingComponent
        if(this.target != null && this.target != target)
        {
            StopCoroutine(Chase());
            hasCoroutineStarted = false;
        }

        // if rat has not seen anyone yet, chase the first target it sees
        if(!hasCoroutineStarted)
        {
            canChase = true;
            hasCoroutineStarted = true;
            this.target = target;
            StartCoroutine(Chase()); 
        }
    }

    public void EndChasing(RatBrain.RatState state)
    {
        stateRef = state;
        if(hasCoroutineStarted)
        {
            canChase = false;
            hasCoroutineStarted = false;
            this.target = null;
            StopCoroutine(Chase());
        }
    }

    public void SetStateRef(RatBrain.RatState state)
    {
        stateRef = state;
    }


    // Update is called once per frame
    //void Update()
    //{
    //    distance = target.transform.position - transform.position;
    //    if (distance.magnitude > stoppingDistance)
    //    {
    //        targetDirection = Vector3.Normalize(distance);
    //        rb.MovePosition(transform.position + (targetDirection * moveSpeed * Time.deltaTime));
    //    }
    //}

    
}
