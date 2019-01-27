using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YouWin : MonoBehaviour
{
    private Image im;
    private Text txt;

    void Start()
    {
        im = GetComponent<Image> ();
        txt = GetComponentInChildren<Text> ();
        StartCoroutine (FadeIn ());
    }

    IEnumerator FadeIn ()
    {
        Time.timeScale = 0f;

        float start = Time.realtimeSinceStartup;
        float fadeTime = 3f;

        Color whiteClear = new Color (1f, 1f, 1f, 0f);
        Color blackClear = new Color (0f, 0f, 0f, 0f);
        im.color = Color.black;// blackClear;
        txt.color = whiteClear;
        while (Time.realtimeSinceStartup - start < fadeTime)
        {
            float t = (Time.realtimeSinceStartup - start) / fadeTime;

            //im.color = Color.Lerp (blackClear, Color.black, t);
            txt.color = Color.Lerp (whiteClear, Color.white, t);

            yield return new WaitForSecondsRealtime (.05f);
        }

        yield return new WaitForSecondsRealtime (3f);

        Time.timeScale = 1f;
        GameManager gm = FindObjectOfType<GameManager> ();
        if (gm)
        {
            gm.LoadNextScene ();
        }
    }
}
