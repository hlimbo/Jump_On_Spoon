using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    
    public bool pickupable;
    public bool withinRange;
    Material mat;
    Vector3 defaultPosition;
    private void Start()
    {
        defaultPosition = transform.position - transform.parent.position;
        mat = GetComponent<MeshRenderer>().material;
    }

    public void highlight()
    {
        GetComponent<Renderer>().material.shader = Shader.Find("Self-Illumin/Outlined Diffuse");
    }
    
    public void standardize()
    {
        GetComponent<Renderer>().material.shader = Shader.Find("Standard");
    }

    public void transparent()
    {
        GetComponent<MeshRenderer>().material = (Material)Resources.Load("Transparent", typeof(Material));

    }

    public void opaque()
    {

        GetComponent<MeshRenderer>().material = mat;
    }

    public void fixPosition()
    {
        transform.position = defaultPosition + transform.parent.position;
    }
}
