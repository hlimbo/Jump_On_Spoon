using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    public Camera camera;
    public float thrust;

    Ray ray;
    Item item;
    GameObject holdItem;
    public GameObject rightClick;
    public GameObject leftClick;
	bool holding = false;
    float holdOffset = 0;
    // Start is called before the first frame update
    void Start()
    {
        ray = new Ray();
        item = null;
        camera = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        ray.origin = camera.transform.position;
        ray.direction = camera.transform.forward;
        Debug.DrawRay(camera.transform.position, camera.transform.forward, Color.black, .01f, false);
        RaycastHit hit;
        leftClick.SetActive(false);
        rightClick.SetActive(false);
        if (Physics.Raycast(ray, out hit, 12f) && hit.transform.GetComponent<Item>())
        {
            item = hit.transform.GetComponent<Item>();
            if (item.pickupable)
            {
                item.withinRange = true;
                item.highlight();
                leftClick.SetActive(true);
                if (Input.GetMouseButtonDown(0) && !holding)
                {
                    holdItem = item.gameObject;
                    holdItem.layer = 13;
                    holdItem.GetComponent<Rigidbody>().isKinematic = true;
                    holding = true;
                    item.standardize();
                    //item.transparent();
                    return;
                }
                
            }
            
        }
        else if (item)
        {
            item.standardize();
            item = null;
        }

        

        // Push mechanic
        if (Physics.Raycast(ray, out hit, 12f) && hit.transform.GetComponent<Rigidbody>())
        {
            rightClick.SetActive(true);
            if (Input.GetMouseButtonDown(1))
                hit.transform.gameObject.GetComponentInParent<Rigidbody>().AddForce(new Vector3(transform.forward.x, 0f, transform.forward.z) * thrust);
        }
        
        if (holding)
        {
            leftClick.SetActive(true);
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
                holdOffset += .25f;
            else if (Input.GetAxis("Mouse ScrollWheel") < 0)
                holdOffset -= .25f;
            holdOffset = Mathf.Clamp(holdOffset, 0f, 5f);
            hold(ray.GetPoint(4f + holdOffset));
            if (Input.GetMouseButtonDown(0))
            {
                holdItem.layer = 12;
                holdItem.GetComponent<Rigidbody>().isKinematic = false;
                holding = false;
                holdItem = null;
                holdOffset = 0;
            }
        }
    }

	void hold(Vector3 holdPosition)
	{
        holdItem.transform.rotation = transform.rotation;
		holdItem.transform.parent.transform.position = holdPosition;
	}
			
}
