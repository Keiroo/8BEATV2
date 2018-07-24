﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

    public GameObject FadeImage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadGameScene()
    {
        FadeImage.GetComponent<Fade>().enabled = true;
        FadeImage.GetComponent<Fade>().SceneName = "GameScene";
    }

    public void LoadMainMenuScene()
    {
        FadeImage.GetComponent<Fade>().enabled = true;
        FadeImage.GetComponent<Fade>().SceneName = "MainMenuScene";
    }
}