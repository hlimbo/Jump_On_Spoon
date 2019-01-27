using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveToTargetComponent))]
public class RatBrain3 : MonoBehaviour
{
    public List<GameObject> waypoints = new List<GameObject>();
    private MoveToTargetComponent mtc;
    private RatBrain.RatState state;
    private int currentIndex = 0;
    [SerializeField]
    private GameObject currentWaypoint;
    // Start is called before the first frame update
    void Start()
    {
        mtc = GetComponent<MoveToTargetComponent>();
        if(waypoints.Count > 0) 
        {
            state = RatBrain.RatState.PATROL;
            currentWaypoint = waypoints[currentIndex];
            mtc.BeginChasing(state, currentWaypoint);
        }
        else
        {
            state = RatBrain.RatState.UNDECIDED;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(waypoints.Count > 0) {
            Vector3 distance = transform.position - mtc.target.transform.position;
            bool isCloseEnough = distance.magnitude < mtc.stoppingDistance;
            if(isCloseEnough) {
                state = RatBrain.RatState.UNDECIDED;
                mtc.EndChasing(state);
                currentIndex = (currentIndex + 1) % waypoints.Count;
                currentWaypoint = waypoints[currentIndex];
                mtc.BeginChasing(state, currentWaypoint);
                state = RatBrain.RatState.PATROL;
            }
        }   
    }
}
