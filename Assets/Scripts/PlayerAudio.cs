using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public static PlayerAudio instance;

    public AudioSource walkRunAudioSource;
    public AudioClip[] sounds;
    public float walkLowPitchRange = .95f;
    public float walkHighPitchRange = 1.05f;
    public float runLowPitchRange;
    public float runHighPitchRange;


    private void OnEnable()
    {
        walkRunAudioSource = GetComponent<AudioSource>();

        if (instance == null)
            instance = this;
        //DontDestroyOnLoad(instance);
    }

    private void OnDisable()
    {
        instance = null;
    }

    public void WalkingAudio()
    {
        walkRunAudioSource.pitch = Random.Range(walkLowPitchRange, walkHighPitchRange);
        walkRunAudioSource.PlayOneShot(sounds[Random.Range(0, 3)]);

        // need audio.stop???
    }

    public void RunningAudio()
    {
        walkRunAudioSource.pitch = Random.Range(runLowPitchRange, walkHighPitchRange);
        walkRunAudioSource.PlayOneShot(sounds[Random.Range(0, 3)]);
    }
}


