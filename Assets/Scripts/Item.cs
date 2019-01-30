using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//INSTRUCTIONS
//1. Place parent anchor point where you would like item to be held
//2. Place item script on child component
//3. The Parent component's Z-axis must point towards item
public class Item : MonoBehaviour
{
    public bool pickupable;
    public bool withinRange;
    public Material transparentMat;
    Material mat;
    Vector3 defaultPosition;
    private void Start()
    {
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

}
