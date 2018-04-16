﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionButtonScript : MonoBehaviour
{
    public string nextScene;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (MultiTouch.IsTouch(gameObject))
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
