using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public bool pickupable;
    public bool withinRange;

    public void highlight()
    {
        GetComponent<Renderer>().material.shader = Shader.Find("Self-Illumin/Outlined Diffuse");
    }

    public void standardize()
    {
        GetComponent<Renderer>().material.shader = Shader.Find("Standard");
    }
}
