using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpoon : MonoBehaviour
{
    public Rigidbody handle;
    private Rigidbody scoopBody;
    public float moveFrequency;
    public float moveSpeed;
    private Vector3 direction = new Vector3(0.0f, -1.0f, 0.0f);
    public Vector3 velocity;

    void Start()
    {
        print(transform.Find("Handle"));
        print(transform.Find("Scoop"));

        handle = transform.Find("Handle").GetComponent<Rigidbody>();
        scoopBody = transform.Find("Scoop").GetComponent<Rigidbody>();
        StartCoroutine(LiftSpoonUpAndDown());
    }

    IEnumerator LiftSpoonUpAndDown()
    {
        while(true)
        {
            float startTime = Time.time;
            float deltaTime = Time.time - startTime;
            while(deltaTime < moveFrequency)
            {
                velocity = direction * moveSpeed * Time.deltaTime;
                handle.MovePosition(handle.position + velocity);
                scoopBody.MovePosition(scoopBody.position + velocity);
                yield return null;
                deltaTime = Time.time - startTime;
            }

            direction = direction * -1.0f;
        }
    }
}
