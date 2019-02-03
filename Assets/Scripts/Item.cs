using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//INSTRUCTIONS
//1. Place parent anchor point where you would like item to be held
//2. Place item script on child component
//3. The Parent component's Z-axis must point towards item and have a fixed joint to physical object
public class Item : MonoBehaviour
{
    private Vector3 defaultPosition;
    private Vector3 defaultRelative;
    private Quaternion defaultRotation;
    public bool pickupable;
    public bool withinRange;
    public Material transparentMat;
    Material mat;
    private void Start()
    {
        if (pickupable)
            defaultRelative = transform.position - transform.parent.position;
        defaultPosition = transform.position;
        defaultRotation = transform.rotation;
        mat = GetComponent<MeshRenderer>().material;
    }

    public void highlight()
    {
        GetComponent<Renderer>().material.shader = Shader.Find("Self-Illumin/Outlined Diffuse");
    }
    
    public void standardize()
    {
        GetComponent<Renderer>().material.shader = Shader.Find("Standard");
        GetComponent<MeshRenderer>().material = mat;
    }

    public void transparent()
    {
        GetComponent<MeshRenderer>().material = transparentMat;
    }

    public void reset()
    {
        transform.position = defaultPosition;
        transform.rotation = defaultRotation;
    }

    public void fixPosition()
    {
        transform.position = transform.parent.position + defaultRelative;
    }

}
