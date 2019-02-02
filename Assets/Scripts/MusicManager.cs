using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MusicManager : MonoBehaviour
{
	public static MusicManager instance;
	public AudioClip[] level_music;

	private AudioSource musicSource;
    private int currentClipIndex = 0;
    // Use this for initialization

    #region SCRIPT SETUP METHODS
    private void OnEnable()
    {
        if (instance == null)
            instance = this;
        SceneManager.sceneLoaded += OnSceneLoaded;

        musicSource = GetComponent<AudioSource>();
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        instance = null;
    }

    // Runs whenever scene is loaded. subscribed to SceneManager.sceneLoaded delegate. Plays level music
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Scene firstScene = SceneManager.GetSceneAt(0);

        if (scene == firstScene)
        {
            musicSource.clip = level_music[currentClipIndex]; 
            musicSource.Play();
        }

        else
        {
            currentClipIndex += 1;
            musicSource.clip = level_music[currentClipIndex];
        }
    }
    #endregion

    void Awake()
	{
        if(FindObjectsOfType<MusicManager>().Length > 1)
        {
            Destroy(gameObject);
        }
		DontDestroyOnLoad (gameObject);
	}
}
