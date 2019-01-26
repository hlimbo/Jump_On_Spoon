using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    
    public bool pickupable;
    public bool withinRange;

    Vector3 defaultPosition;
    private void Start()
    {
        defaultPosition = transform.position - transform.parent.position;
    }

    public void highlight()
    {
        GetComponent<Renderer>().material.shader = Shader.Find("Self-Illumin/Outlined Diffuse");
    }
    
    public void standardize()
    {
        GetComponent<Renderer>().material.shader = Shader.Find("Standard");
    }

    public void fixPosition()
    {
        transform.position = defaultPosition + transform.parent.position;
    }
}
