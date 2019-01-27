using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensingComponent : MonoBehaviour
{
    private SphereCollider sensingCollider;
    [SerializeField]
    private List<GameObject> objectsWithinRadius = new List<GameObject>();
    [SerializeField]
    private GameObject targetToFollow = null;

    // Start is called before the first frame update
    void Start()
    {
        sensingCollider = GetComponent<SphereCollider>();
    }

    //private void Update()
    //{
    //    DetermineTargetToFollow();
    //}

    private void DetermineTargetToFollow()
    {
        foreach(GameObject target in objectsWithinRadius)
        {
            // does not take into account of which cheese to follow if multiple cheeses are in the scene
            if(target.tag == Tags.CHEESE)
            {
                targetToFollow = target;
                break;
            }
            else if(target.tag == Tags.PLAYER)
            {
                targetToFollow = target;
            }
        }

        if(objectsWithinRadius.Count == 0)
        {
            targetToFollow = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag == Tags.CHEESE || other.tag == Tags.PLAYER)
       {
            print("I See "+ other.tag);
            objectsWithinRadius.Add(other.gameObject);
            DetermineTargetToFollow();
       }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == Tags.CHEESE || other.tag == Tags.PLAYER)
        {
            print("I don't see " + other.tag);
            objectsWithinRadius.Remove(other.gameObject);
            DetermineTargetToFollow();
        }
    }

    // null means this entity does not see anything within range
    public GameObject GetTarget()
    {
        return targetToFollow;
    }

    public bool HasTargetToFollow()
    {
        return targetToFollow != null;
    }

}
