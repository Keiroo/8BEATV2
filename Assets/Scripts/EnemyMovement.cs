using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    
    public float MoveSpeed = 3f;

    Vector3 moveDirection;
    int rotationSpeed = 90;
    int rotationDir = 0;

    // Use this for initialization
    void Start () {
        rotationDir = Random.Range(0, 2);
        moveDirection = new Vector3(0f, -MoveSpeed);
        rotationSpeed = Random.Range(60, 180);
    }


	
	// Update is called once per frame
	void Update () {
        if (rotationDir == 0) transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        else transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);

        transform.localPosition += moveDirection * Time.deltaTime;
	}
}
