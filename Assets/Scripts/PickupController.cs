using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    Camera camera;
	GameObject holdItem;
	bool holding = false;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, camera.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2.5f))
        {
			Item item = hit.transform.GetComponent<Item>();
			if (item.pickupable) {
				item.withinRange = true;
				if (Input.GetMouseButtonDown (0) && !holding) 
				{
					holdItem = item.gameObject;
					holdItem.GetComponent<Rigidbody>().isKinematic = true;
					holding = true;
				}
				else if(Input.GetMouseButtonDown (0) && holding)
				{
					holdItem.GetComponent<Rigidbody>().isKinematic = false;
					holding = false;
					holdItem = null;
				}
			}
        }
		hold (ray.GetPoint(1.75f));
    }

	void hold(Vector3 holdPosition)
	{
		if (holding) {
			holdItem.transform.position = holdPosition;
		}
	}
			
}
