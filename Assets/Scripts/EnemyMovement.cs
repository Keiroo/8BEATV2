using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    Vector3 moveDirection;

    float moveSpeed = 3f;
    float rotationSpeed = 70f;

	// Use this for initialization
	void Start () {
        moveDirection = new Vector3(0f, -moveSpeed);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        transform.localPosition += moveDirection * Time.deltaTime;
	}
}
