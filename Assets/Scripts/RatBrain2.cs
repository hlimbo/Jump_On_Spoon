using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SensingComponent), typeof(MoveToTargetComponent))]
public class RatBrain2 : MonoBehaviour
{

    /*
        rat goes into idle when
            rat loses track of target
        rat goes to chase when
            rat sees a target based on priority
     */

    [SerializeField]
     private RatBrain.RatState state = RatBrain.RatState.IDLE;
     private SensingComponent sensingComp;
     private MoveToTargetComponent moveToTargetComp;

    // Start is called before the first frame update
    void Start()
    {
        sensingComp = GetComponent<SensingComponent>();
        moveToTargetComp = GetComponent<MoveToTargetComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(sensingComp.HasTargetToFollow())
        {
            state = RatBrain.RatState.CHASE;
            GameObject target = sensingComp.GetTarget();
            moveToTargetComp.BeginChasing(state, target);
        }
        else
        {
            state = RatBrain.RatState.PATROL;
            moveToTargetComp.EndChasing(state);
        }
    }
}
