using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

    public GameObject FadeImage;
    public AudioSource AudioSource;
    public AudioClip[] DefeatClips;
    public AudioClip Button;

	// Use this for initialization
	void Start () {
		if (AudioSource != null)
        {
            if (DefeatClips.Length > 0)
            {
                int ranIndex = UnityEngine.Random.Range(0, DefeatClips.Length);

                AudioSource.clip = DefeatClips[ranIndex];
                AudioSource.loop = false;
                AudioSource.Play();
            }
        }
	}

    public void LoadGameScene()
    {
        PlayButtonEffect();
        FadeImage.GetComponent<Fade>().enabled = true;
        FadeImage.GetComponent<Fade>().SceneName = "GameScene";
    }    

    public void LoadMainMenuScene()
    {
        PlayButtonEffect();
        FadeImage.GetComponent<Fade>().enabled = true;
        FadeImage.GetComponent<Fade>().SceneName = "MainMenuScene";
    }

    private void PlayButtonEffect()
    {
        if (AudioSource != null)
        {
            if (Button != null)
            {
                AudioSource.Stop();
                AudioSource.clip = Button;
                AudioSource.loop = false;
                AudioSource.Play();
            }
        }
    }
}
