using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// Game Manager Script. Loads next scene. Counts time from start of game. Isn't destroyed on load. 
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int timeFromStart;

    #region  UNITY CALLBACKS       
    void OnEnable() 
    {
        if (instance == null)
            instance = this;

        DontDestroyOnLoad(gameObject);
    }

    void OnDisable()
    {
        instance = null;
    }
#endregion

    IEnumerator CoKeepTrackOfTime()
    {
        yield return WaitForSeconds(1);
        timeFromStart += Time.deltaTime;
        yield return null;
    }

    public LoadNextScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene((int)scene.buildIndex + 1);
    }

    // Called when player finishes game
    public EndGame()
    {
        print(timeFromStart);
    }
}
