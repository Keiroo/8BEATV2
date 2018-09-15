using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject FadeImage;
    public AudioSource AudioSource;
    public AudioClip BGM;
    public AudioClip Button;

	// Use this for initialization
	void Start () {
		if (AudioSource != null)
        {
            if (BGM != null)
            {
                AudioSource.clip = BGM;
                AudioSource.loop = true;
                AudioSource.Play();
            }
        }
	}

    public void LoadGameScene()
    {
        if (AudioSource != null)
        {
            if (Button != null)
            {
                AudioSource.Stop();
                AudioSource.loop = false;
                AudioSource.volume = 0.5f;
                AudioSource.clip = Button;
                AudioSource.Play();
            }
        }
        FadeImage.GetComponent<Fade>().enabled = true;
    }
}
