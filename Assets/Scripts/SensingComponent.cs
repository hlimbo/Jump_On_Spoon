using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensingComponent : MonoBehaviour
{
    private SphereCollider sensingCollider;
    [SerializeField]
    private List<GameObject> objectsWithinRadius = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        sensingCollider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
       if(other.gameObject.tag == Tags.RAT)
       {
            objectsWithinRadius.Add(other.gameObject);
            print("I See Rat");
       }
       else if(other.gameObject.tag == Tags.CHEESE)
       {
            print("I See Cheese");
            objectsWithinRadius.Add(other.gameObject);
        }
       else if(other.gameObject.tag == Tags.PLAYER)
       {
            print("I See Player");
            objectsWithinRadius.Add(other.gameObject);
        }
 
    }

    public GameObject GetLastSeenObject()
    {
        return lastSeenObject;
    }
}
