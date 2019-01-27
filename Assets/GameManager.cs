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
        SceneManager.LoadScene((int)scene.buildIndex + 1);
    }

    public void EndGame()
    {
        //creditsPanel.SetActive(true);
        print(timeSinceStart);
    }
}
