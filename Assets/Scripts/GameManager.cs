using System;
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
    public GameObject fadeImage;
    public GameObject EnemySpawner;
    public GameObject Camera;
    public GameObject[] Hearts;
    public GameObject BGM;
    public float SpeedUpEnemyMovement = 1.2f;
    public float SpeedUpEnemySpawnTime = 0.8f;
    public int SpeedUpThreshold = 50;
    public float SpeedUpThresholdCoeff = 2.5f;
    public int ComboThreshold = 5;
    public int MaxMultiplier = 16;
    public int MaxLevel = 5;
    public bool newLvl = true;

    private int healthPoints = 3;
    private int points = 0;
    private int multiplier = 1;
    private int combo = 0;
    private bool isAlive = true;    
    private int thresholdCount = 1;
    private int level = 1;
    private float firstLvlTimer = 0f;
    private bool firstLvlBGMPlayed = false;
    

    // for audio debugging
    private float audioTimer = 0;
    DebugFileWriter dfw;

    // Use this for initialization
    void Start () {
        dfw = GetComponent<DebugFileWriter>();
    }
	
	// Update is called once per frame
	void Update () {

        // for audio debugging
        audioTimer += Time.deltaTime;

        // 1st level starts playing earlier than others
        if (level == 1 && !firstLvlBGMPlayed)
        {
            firstLvlTimer += Time.deltaTime;
            if (firstLvlTimer > 0.5f)
            {
                PlayBGM();
                firstLvlBGMPlayed = true;
            }

        }

        HPCounter.GetComponent<Text>().text = "HP: " + healthPoints;
        ScoreCounter.GetComponent<Text>().text = points.ToString();
        MultiplierCounter.GetComponent<Text>().text = "X" + multiplier;

        if (!isAlive)
            if (!devMode)
            {
                int highscore = PlayerPrefs.GetInt("highscore");
                if (points > highscore) PlayerPrefs.SetInt("highscore", points);
                fadeImage.GetComponent<Fade>().enabled = true;                
            }     
        
        if (points / SpeedUpThreshold >= thresholdCount)
        {
            if (level <= MaxLevel)
            {
                level++;
                audioTimer = 0;
                SpeedUpEnemies();
                thresholdCount++;
            }
            
        }
	}

    public int GetLevel()
    {
        return level;
    }

    public int GetHealthPoints()
    {
        return healthPoints;
    }

    public bool GetDevMode()
    {
        return devMode;
    }

    public void PlayBGM()
    {
        BGM.GetComponent<BGM>().PlayBGM(level);
    }

    public void LoseHealthPoint()
    {
        healthPoints--;
        combo = 0;
        multiplier = 1;
        Camera.GetComponent<CameraShake>().enabled = true;

        // Hearts code
        Hearts[healthPoints].GetComponent<HeartVanish>().enabled = true;
        BGM.GetComponent<BGM>().PlayHeartEffect();

        if (healthPoints <= 0) isAlive = false;
    }

    public void AddPoints()
    {
        combo += 1;

        if (combo >= ComboThreshold)
        {
            combo = 0;
            multiplier *= 2;
            if (multiplier > MaxMultiplier) multiplier = MaxMultiplier;
            else MultiplierCounter.GetComponent<MultiplierAnimation>().enabled = true;
        }

        points += 1 * multiplier;
    }

    

    public void SpeedUpEnemies()
    {
        BGM.GetComponent<BGM>().StopBGM();
        BGM.GetComponent<BGM>().PlayTransEffect(level - 1);
        newLvl = true;

        // Camera colors
        Camera.GetComponent<CameraColorChange>().enabled = true;

        int i = 0;
        GameObject[] children = new GameObject[EnemySpawner.transform.childCount];

        foreach (Transform child in EnemySpawner.transform)
        {
            children[i] = child.gameObject;
            i++;
        }

        foreach (GameObject child in children)
        {
            Destroy(child);
        }

        EnemySpawner.GetComponent<EnemySpawner>().SpawnTime *= SpeedUpEnemySpawnTime;
        EnemySpawner.GetComponent<EnemySpawner>().EnemySpeed *= SpeedUpEnemyMovement;

        SpeedUpThreshold = (int)(SpeedUpThreshold * SpeedUpThresholdCoeff);
    }

    // for audio debugging
    public void PrintAudioTimer()
    {
        if (newLvl) dfw.WriteLevel(level);
        dfw.WriteTimer(audioTimer);
        Debug.Log(audioTimer);
    }
}
