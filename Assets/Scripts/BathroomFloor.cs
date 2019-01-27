using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomFloor : MonoBehaviour
{
    private void OnCollisionEnter (Collision collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.tag == "Player")
            {
                SpawnPoint.Respawn (collision.rigidbody.transform);
            }
        }
    }
}
