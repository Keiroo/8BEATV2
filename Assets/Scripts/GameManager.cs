using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public bool devMode;
    public GameObject HPCounter;
    public GameObject ScoreCounter;
    public GameObject MultiplierCounter;
    public Image fadeImage;

    int healthPoints = 3;
    int points = 0;
    int multiplier = 1;
    int combo = 0;
    bool isAlive = true;

	// Use this for initialization
	void Start () {
        //Color imageColor = fadeImage.color;
        //fadeImage.color = new Color(imageColor.r, imageColor.b, imageColor.b, 0f);
	}
	
	// Update is called once per frame
	void Update () {
        HPCounter.GetComponent<Text>().text = "HP: " + healthPoints;
        ScoreCounter.GetComponent<Text>().text = points.ToString();
        MultiplierCounter.GetComponent<Text>().text = "X" + multiplier;

        if (!isAlive)
            if (!devMode)
            {
                int highscore = PlayerPrefs.GetInt("highscore");
                if (points > highscore) PlayerPrefs.SetInt("highscore", points);
                Time.timeScale = 0f;
                StartCoroutine(Fade());
            }          
	}

    public int GetHealthPoints()
    {
        return healthPoints;
    }

    public void LoseHealthPoint()
    {
        healthPoints--;
        combo = 0;
        multiplier = 1;
        if (healthPoints <= 0) isAlive = false;
    }

    public void AddPoints()
    {
        combo += 1;

        if (combo > 10)
        {
            combo = 0;
            multiplier *= 2;
        }


        points += 1 * multiplier;
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
        Time.timeScale = 1f;
        yield return null;
    }
}
