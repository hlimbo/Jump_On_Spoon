using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerealBit : MonoBehaviour
{
    public float bobbingSpeed;
    [Tooltip("How many seconds it takes to travel in the y direction before inverting direction")]
    public float bobFrequency;
    [SerializeField]
    private Vector3 initialDirection = Vector3.down;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartBobbing());
    }

    IEnumerator StartBobbing()
    {
        while (true)
        {
            float startTime = Time.time;
            float deltaTime = Time.time - startTime;
            while(deltaTime < bobFrequency)
            {

                yield return null;
                deltaTime = Time.time - startTime;
            }
        }
    }
}
