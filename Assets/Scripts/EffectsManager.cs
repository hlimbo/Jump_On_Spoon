using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;
/// <summary>
/// References other scripts (RigidbodyFirstPersonController) to know when to call audio and visual effects. 
/// </summary>
public class EffectsManager : MonoBehaviour
{
    public static EffectsManager instance;
    [SerializeField]
    private RigidbodyFirstPersonController rfpc;

    #region SCRIPT SETUP METHODS
    private void OnEnable()
    {
        if (instance == null)
            instance = this;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        instance = null;
    }

    // Runs whenever scene is loaded. subscribed to SceneManager.sceneLoaded delegate. Finds and stores reference to RigidBodyFirstPersonController script. 
    // This provides persistence without making the rfpc a singleton. Making it a singleton would require hand-placing player original spawns and other states. Will
    // get to that, but this is a stop-gap solution until level design and player prefab revisions are more stable
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        rfpc = GameObject.FindGameObjectWithTag("Player").GetComponent<RigidbodyFirstPersonController>();
    }
    #endregion

    void Update()
    {
        // grounded and moving check
        if (rfpc.Velocity.sqrMagnitude > 0f && rfpc.Grounded)
        {
            if (!rfpc.Running)
                WalkingFX();

            else
                RunningFX();
        }
    }

    private void WalkingFX()
    {
        // walking audio
        if (!PlayerAudio.instance.walkRunAudioSource.isPlaying)
        {
            PlayerAudio.instance.WalkingAudio();
        }

        // particles, animation, etc. 
    }

    private void RunningFX()
    {
        if (!PlayerAudio.instance.walkRunAudioSource.isPlaying)
        {
            PlayerAudio.instance.RunningAudio();
        }
    }
}
