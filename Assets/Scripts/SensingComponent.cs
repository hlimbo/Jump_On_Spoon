using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensingComponent : MonoBehaviour
{
    private SphereCollider sensingCollider;
    [SerializeField]
    private Dictionary<string, GameObject> objectsWithinRadius = new Dictionary<string, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        sensingCollider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
       
       if(other.gameObject.tag == Tags.RAT || other.tag == Tags.CHEESE || other.gameObject.tag == Tags.PLAYER)
       {
            print("I See "+other.gameObject.tag);
            objectsWithinRadius.Add(other.gameObject.tag, other.gameObject);
       }
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
    public GameObject GetTarget()
    {
        if(objectsWithinRadius.Keys

        if (tags.Contains(Tags.CHEESE))
        {

        } else if (tags.Contains(Tags.Cheese))
        return lastSeenObject;
    }
}
