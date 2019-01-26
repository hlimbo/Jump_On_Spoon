﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingComponent : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 moveDirection;
    [Tooltip("Time in seconds unit moves in one direction")]
    public float paceFrequency;
    public bool canPatrol = true;

    private Rigidbody rb;
    [SerializeField]
    private Vector3 currentMoveDirection;
    private bool hasCoroutineStarted = false;

    void Start()
    {
        currentMoveDirection = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);
        rb = GetComponent<Rigidbody>();
        hasCoroutineStarted = true;
        StartCoroutine(Patrol());
    }

    IEnumerator Patrol()
    {
        while (canPatrol)
        {
            float startTime = Time.time;
            float deltaTime = Time.time - startTime;
            while (deltaTime < paceFrequency)
            {
                rb.MovePosition(transform.position + (currentMoveDirection * moveSpeed * Time.deltaTime));
                yield return null;
                deltaTime = Time.time - startTime;
            }

            currentMoveDirection = currentMoveDirection * -1.0f;
        }
    }

    private void Update()
    {
        if(!canPatrol)
        {
            StopCoroutine(Patrol());
            hasCoroutineStarted = false;
        }
        else if(!hasCoroutineStarted && canPatrol) 
        {
            hasCoroutineStarted = true;
            StartCoroutine(Patrol());
        }
    }
}
