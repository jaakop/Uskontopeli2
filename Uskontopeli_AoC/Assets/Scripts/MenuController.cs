﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public Transform loadingCanvas;
    public Transform mainCanvas;
    public Transform creditsCanvas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NewGame()
    {
        loadingCanvas.gameObject.SetActive(true);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exited");
    }

    public void Credits()
    {
        creditsCanvas.gameObject.SetActive(true);
        mainCanvas.gameObject.SetActive(false);
    }

}
