using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    
    public bool pickupable;
    public bool withinRange;
    void OnMouseOver()
    {
        if (pickupable && withinRange)
        {
            Debug.Log("Highlighting");
            GetComponent<Renderer>().material.shader = Shader.Find("Self-Illumin/Outlined Diffuse");
			withinRange = false;
        }
    }

    void OnMouseExit()
    {
        Debug.Log("unhighlighting");
        GetComponent<Renderer>().material.shader = Shader.Find("Standard");

    }
}
