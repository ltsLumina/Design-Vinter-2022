using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    SceneLoader sceneLoader;

    void Start()
    {
        sceneLoader = GetComponent<SceneLoader>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            sceneLoader.ReloadScene();
        }
    }
}