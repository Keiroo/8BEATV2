using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    Vector3 moveDirection;

    float moveSpeed = 3f;
    float rotationSpeed = 90f;
    int rotationDir = 0;

    // Use this for initialization
    void Start () {
        rotationDir = Random.Range(0, 2);
        moveDirection = new Vector3(0f, -moveSpeed);
    }
	
	// Update is called once per frame
	void Update () {
        if (rotationDir == 0) transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        else transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);

        transform.localPosition += moveDirection * Time.deltaTime;
	}
}
