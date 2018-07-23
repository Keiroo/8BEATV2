using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject[] Enemies;

    public float SpawnTime = 1f;
    public float EnemySpeed = 3f;

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
            yield return new WaitForSeconds(SpawnTime);
            SpawnEnemy();
        }        
    }

    public void SpawnEnemy()
    {
        int enemyID = Random.Range(0, 3);
        GameObject enemy = Instantiate(Enemies[enemyID], transform);
        enemy.GetComponent<EnemyMovement>().MoveSpeed = EnemySpeed;
    }
}
