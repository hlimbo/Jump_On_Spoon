using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    public Camera camera;
    public float thrust;

    float holdOffset = 0;
    
    Item item;
    GameObject holdItem;
	bool holding = false;
    // Start is called before the first frame update
    void Start()
    { 
        item = null;
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, camera.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 6f) && hit.transform.GetComponent<Item>())
        {
            item = hit.transform.GetComponent<Item>();
            if (item.pickupable)
            {
                item.withinRange = true;
                item.highlight();
                if (Input.GetMouseButtonDown(0) && !holding)
                {
                    holdItem = item.gameObject;
                    holdItem.layer = 13;
                    holdItem.GetComponent<Rigidbody>().isKinematic = true;
                    holding = true;
                    item.standardize();
                    //item.transparent();
                }
                else if (Input.GetMouseButtonDown(0) && holding)
                {
                    holdItem.layer = 12;
                    holdItem.GetComponent<Rigidbody>().isKinematic = false;
                    holding = false;
                    item.standardize();
                    holdItem = null;
                }
            }
            
        }
        else if (item)
        {
            item.standardize();
            item = null;
        }
        if (Physics.Raycast(ray, out hit, 6f) && Input.GetMouseButton(1) && hit.transform.GetComponent<Rigidbody>())
        {
            hit.transform.gameObject.GetComponentInParent<Rigidbody>().AddForce(new Vector3(transform.forward.x, 0f, transform.forward.z) * thrust);
        }
        
        if (holding)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
                holdOffset += .25f;
            else if (Input.GetAxis("Mouse ScrollWheel") < 0)
                holdOffset -= .25f;
            holdOffset = Mathf.Clamp(holdOffset, 0f, 3f);
            hold(ray.GetPoint(4f + holdOffset));
        }
    }

	void hold(Vector3 holdPosition)
	{
        holdItem.transform.forward = transform.forward;
		holdItem.transform.parent.transform.position = holdPosition;
        holdItem.GetComponent<Item>().fixPosition();
	}
			
}
