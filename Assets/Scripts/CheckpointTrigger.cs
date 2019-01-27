using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    public SpawnPoint spawn;

    private void Awake ()
    {
        if (!spawn)
        {
            Debug.LogWarning (name + " doesn't have assigned spawn point");
        }
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            SpawnPoint.ActivateSpawnPoint (spawn);
            MeshRenderer mr = GetComponentInChildren<MeshRenderer> ();
            if (mr) mr.enabled = false;
        }
    }
}
