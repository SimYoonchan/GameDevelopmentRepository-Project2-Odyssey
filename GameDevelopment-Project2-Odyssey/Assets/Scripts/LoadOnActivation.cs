using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnActivation : MonoBehaviour
{
    SceneLoader sceneLoader;

    private void Start()
    {
        //sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void OnEnable()
    {
        //sceneLoader.GoToNextScene();
        SceneManager.LoadScene("23. End Credit");
    }
}
