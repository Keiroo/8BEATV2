using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public bool devMode;
    public GameObject HPCounter;
    public GameObject ScoreCounter;
    public Image fadeImage;

    int healthPoints = 3;
    int points = 0;
    bool isAlive = true;

	// Use this for initialization
	void Start () {
        //Color imageColor = fadeImage.color;
        //fadeImage.color = new Color(imageColor.r, imageColor.b, imageColor.b, 0f);
	}
	
	// Update is called once per frame
	void Update () {
        HPCounter.GetComponent<HPCounter>().UpdateHP(healthPoints);
        ScoreCounter.GetComponent<ScoreCounter>().UpdateScore(points);

        if (!isAlive)
            if (!devMode)
            {
                Time.timeScale = 0f;
                StartCoroutine(Fade());
            }
            //SceneManager.LoadScene("EndGameScene");
	}

    public int GetHealthPoints()
    {
        return healthPoints;
    }

    public void LoseHealthPoint()
    {
        healthPoints--;
        if (healthPoints <= 0) isAlive = false;
    }

    public void AddPoints()
    {
        points += 100;
        print(points);
    }

    IEnumerator Fade()
    {

        while (fadeImage.color.a < 1f)
        {
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, fadeImage.color.a + 0.005f);
            yield return null;
        }
        SceneManager.LoadScene("EndGameScene");
        yield return null;
    }
}
