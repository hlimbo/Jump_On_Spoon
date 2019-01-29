using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerAudio : MonoBehaviour
{

    public AudioClip[] sounds;
    public float lowPitchRange = .95f;
    public float highPitchRange = 1.05f;

    RigidbodyFirstPersonController rfpc;
    AudioSource audio;
    private void Start()
    {
        rfpc = GetComponent<RigidbodyFirstPersonController>();
        audio = GetComponent<AudioSource>();
    }

    

    // Update is called once per frame
    void Update()
    {
        if(rfpc.Velocity.sqrMagnitude > 0f)
        {
            if(!audio.isPlaying)
            {
                if (rfpc.Grounded)
                {
                    audio.pitch = Random.Range(lowPitchRange, highPitchRange);
                    audio.PlayOneShot(sounds[Random.Range(0, 3)]);
                }
            }
        }
        else
        {
            audio.Stop();
        }
    }
}
