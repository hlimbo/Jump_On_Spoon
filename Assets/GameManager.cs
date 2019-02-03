using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //public GameObject creditsPanel;

    private float timeSinceStart;

    #region UNITY CALLBACKS
    private void Update ()
    {
        if (Input.GetKey (KeyCode.LeftShift) && Input.GetKeyDown (KeyCode.L))
        {
            LoadNextScene ();
        }
    }

    private void OnEnable()
    {
        if (instance == null)
            instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private void OnDisable()
    {
        instance = null;
    }
    #endregion

    IEnumerator CoKeepTrackOfTime()
    {
        yield return new WaitForSeconds(1);
        timeSinceStart += Time.deltaTime;
        yield return null;
    }

    public void LoadNextScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        int nextSceneNum = scene.buildIndex + 1;
        print ("scene num plus 1 " + nextSceneNum);
        print ("scenemanage.scene count " + SceneManager.sceneCountInBuildSettings);
        if (nextSceneNum >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.Log ("wrapping scene load build index, bc we're skipping family room");
            nextSceneNum = 0;
        }
        SceneManager.LoadScene (nextSceneNum);
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void EndGame()
    {
        LoadScene("Credits");
        print(timeSinceStart);
    }

    public void Quit()
    {
        Application.Quit(1);
    }
}
