using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{

	public AudioClip[] sound;
	AudioSource audio;


    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    
    void OnCollisionEnter(Collision collision)
    {
        audio.clip = sound[0];
        audio.Play();
    }

    // void OnCollisionStay(Collision collision)
    // {
    // 	audio.clip = sound[1];
    //     audio.Play();
    // }

}
