﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SpawnPoint : MonoBehaviour
{
    public int num;

    private static SpawnPoint activeSpawnPoint;
    private static Vector3 activeSpawnPosition;
    private static Quaternion activeSpawnRotation;

    void Start()
    {
        GetComponent<MeshRenderer> ().enabled = false;
        name = "SpawnPoint_" + num;
    }

    public static void ActivateSpawnPoint (SpawnPoint newSpawn)
    {
        if (activeSpawnPoint)
        {
            if (newSpawn.num < activeSpawnPoint.num)
            {
                Debug.Log ("not activating a lower numbered spawn point");
                return;
            }
        }

        activeSpawnPoint = newSpawn;
        activeSpawnPosition = activeSpawnPoint.transform.position;
        activeSpawnRotation = activeSpawnPoint.transform.rotation;
    }

    public static void Respawn (Transform t)
    {
        if (!activeSpawnPoint)
        {
            SpawnPoint[] spawnPoints = FindObjectsOfType<SpawnPoint> ();
            int lowestNum = 999;
            SpawnPoint lowestPoint = null;
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if (spawnPoints[i].num < lowestNum)
                {
                    lowestPoint = spawnPoints[i];
                    lowestNum = lowestPoint.num;
                }
            }

            ActivateSpawnPoint (lowestPoint);
        }


        t.position = activeSpawnPosition;
        t.rotation = activeSpawnRotation;

        RigidbodyFirstPersonController rfpc  = t.GetComponentInChildren<RigidbodyFirstPersonController> ();
        if (rfpc)
        {
            rfpc.OverrideMouseLook (t);
        }

        Rigidbody body = t.GetComponentInChildren<Rigidbody> ();
        body.Sleep ();
    }
}