using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    float holdOffset = 0;
    Camera camera;
    Item item;
    GameObject holdItem;
	bool holding = false;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        item = null;
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, camera.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 3f) && hit.transform.GetComponent<Item>())
        {
            item = hit.transform.GetComponent<Item>();
            if (item.pickupable)
            {
                item.withinRange = true;
                item.highlight();
                if (Input.GetMouseButtonDown(0) && !holding)
                {
                    holdItem = item.gameObject;
                    holdItem.GetComponent<Rigidbody>().isKinematic = true;
                    holding = true;
                }
                else if (Input.GetMouseButtonDown(0) && holding)
                {
                    holdItem.GetComponent<Rigidbody>().isKinematic = false;
                    holding = false;
                    holdItem = null;
                }
            }
        }
        else if (item)
        {
            item.standardize();
            item = null;
        }
        if (holding)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
                holdOffset += .25f;
            else if (Input.GetAxis("Mouse ScrollWheel") < 0)
                holdOffset -= .25f;
            holdOffset = Mathf.Clamp(holdOffset, 0f, 1f);
            hold(ray.GetPoint(2f + holdOffset));
        }
    }

	void hold(Vector3 holdPosition)
	{
        item.transparent();
		holdItem.transform.parent.transform.position = holdPosition;
	}
			
}
