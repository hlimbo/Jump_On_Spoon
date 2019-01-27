using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomFloor : MonoBehaviour
{
    public bool familyRoomFloor = false;
    public bool kill = true;

    private void OnCollisionEnter (Collision collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.tag == "Player")
            {
                if (kill) SpawnPoint.Respawn (collision.rigidbody.transform);

                if (familyRoomFloor && SpawnPoint.acitveSpawnNum == 0)
                {
                    print ("turning off floor");
                    kill = false;
                }
            }
        }
    }
}
