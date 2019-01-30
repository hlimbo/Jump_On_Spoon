using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    public SpawnPoint spawn;
    public bool acitvateFloor = false;

    private void Awake ()
    {
        if (!spawn)
        {
            Debug.LogWarning (name + " doesn't have assigned spawn point");
        }

        MeshRenderer mr = GetComponentInChildren<MeshRenderer> ();
        if (mr) mr.enabled = false;
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
                SpawnPoint.ActivateSpawnPoint (spawn);
            
        }
    }
}
