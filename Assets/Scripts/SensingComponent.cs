using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensingComponent : MonoBehaviour
{
    private SphereCollider sensingCollider;

    // Start is called before the first frame update
    void Start()
    {
        print(Tags.RAT);
        sensingCollider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag == Tags.RAT)
        {
            print("I See Rat");
        }
    }
}
