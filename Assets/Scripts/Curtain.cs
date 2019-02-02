using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curtain : MonoBehaviour
{

    private void Start()
    {
        off();
    }

    public void on()
    {
        GetComponent<SpriteRenderer>().color = Color.black;
    }

    public void off()
    {
        GetComponent<SpriteRenderer>().color = Color.clear;
    }
}
