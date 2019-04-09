﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        gameObject.SetActive(true);
    }
    private void OnLevelWasLoaded(int level)
    {
        gameObject.SetActive(true);
    }
}