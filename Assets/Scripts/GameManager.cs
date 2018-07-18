using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject HPCounter;
    public GameObject ScoreCounter;

    int healthPoints = 3;
    int points = 0;
    bool isAlive = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        HPCounter.GetComponent<HPCounter>().UpdateHP(healthPoints);
        ScoreCounter.GetComponent<ScoreCounter>().UpdateScore(points);
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
}
