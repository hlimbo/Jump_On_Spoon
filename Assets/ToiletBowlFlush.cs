using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletBowlFlush : MonoBehaviour
{
    public AudioClip flushSound;
    public GameObject blackCurtainPrefab;

    private AudioSource aSource;
    private bool flushed = false;

    private void Awake ()
    {
        aSource = GetComponent<AudioSource> ();
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            if (!flushed)
            {
                StartCoroutine (Flush (other.transform));
                flushed = true;
            }
        }
    }

    private IEnumerator Flush (Transform t)
    {
        aSource.PlayOneShot (flushSound);

        Instantiate (blackCurtainPrefab, t.position + t.forward * 5f, t.rotation, t);
        float blackTime = 2f;
        float start = Time.time;

        yield return new WaitForSeconds (blackTime);

        GameManager gm = FindObjectOfType<GameManager> ();
        if (gm)
        {
            gm.LoadNextScene ();
        }
    }

}
