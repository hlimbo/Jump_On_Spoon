using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRat : MonoBehaviour
{
    private MovingComponent move;
    private float startTime;
    private float deltaTime;
    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<MovingComponent>();
        startTime = Time.time;
        deltaTime = Time.time - startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(deltaTime > move.paceFrequency)
        {
            print("Rat Rotated");
            Vector3 projectedDistance =  move.moveDirection * move.moveSpeed * move.paceFrequency;
            Vector3 distance = projectedDistance - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, projectedDistance, move.moveSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);
            startTime = Time.time;
        }

        deltaTime = Time.time - startTime;
    }
}
