using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatPlayer : MonoBehaviour
{
    public GameObject WinCanvas;

    private void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            Rigidbody body = other.GetComponent<Rigidbody> ();

            // Check if kinematic, not just trampolining or something, but stuck to spoon!
            if (body.isKinematic)
            {
                //GameManager gm = FindObjectOfType<GameManager> ();
                //if (gm)
                //{
                //    gm.EndGame ();
                //}
                //else
                //{
                //    body.isKinematic = false;
                //    body.transform.SetParent (null);
                //    StartCoroutine (RespawnPlayer (body.transform));
                //}
                WinCanvas.SetActive(true);
            }
        }
    }

    IEnumerator RespawnPlayer (Transform t)
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime (3f);
        Time.timeScale = 1f;
        SpawnPoint.Respawn (t);
    }

}
