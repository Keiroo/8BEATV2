using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject[] Enemies;

    float minSpawnTime = 0.7f;
    float maxSpawnTime = 1.0f;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(SpawnCoroutine());
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(spawnTime);
            print(spawnTime);
            SpawnEnemy();
        }        
    }

    public void SpawnEnemy()
    {
        int enemyID = Random.Range(0, 3);
        Instantiate(Enemies[enemyID], transform);
        print(transform.position);

    }
}
