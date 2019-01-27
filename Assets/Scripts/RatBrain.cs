using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SensingComponent), typeof(MovingComponent), typeof(MoveToTargetComponent))]
public class RatBrain : MonoBehaviour
{
    [Serializable]
    public enum RatState
    {
        PATROL,
        CHASE,
        UNDECIDED,
        IDLE
    }

    [SerializeField]
    private RatState state;

    private SensingComponent sensingComp;
    private MovingComponent movingComp;
    private MoveToTargetComponent moveToTargetComp;

    // Possible Rat States
    /*
     * 1. Patrolling
     * 2. Chasing
     */ 

    // Start is called before the first frame update
    void Start()
    {
        sensingComp = GetComponent<SensingComponent>();
        movingComp = GetComponent<MovingComponent>();
        moveToTargetComp = GetComponent<MoveToTargetComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(sensingComp.HasTargetToFollow())
        {
            state = RatState.CHASE;
            movingComp.EndPatrolling(state);
            GameObject target = sensingComp.GetTarget();
            moveToTargetComp.BeginChasing(state, target);
            
        }
        else
        {
            state = RatState.PATROL;
            movingComp.BeginPatrolling(state);
            moveToTargetComp.EndChasing(state);
        }
    }
}
