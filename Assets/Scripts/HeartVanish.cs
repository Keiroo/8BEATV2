using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartVanish : MonoBehaviour {

    private Vector3 orgScale;
    private Quaternion orgRotation;
    private float speed = 5.0f;
    private float rotateSpeed = 1800f;

    private void OnEnable()
    {
        orgScale = transform.localScale;
        orgRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update () {
        transform.localScale = new Vector3(transform.localScale.x - Time.deltaTime * speed, 
                                            transform.localScale.y - Time.deltaTime * speed, 
                                            1f);

        transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);

        if (transform.localScale.x < 0.01)
        {
            gameObject.SetActive(false);
            transform.localScale = orgScale;
            transform.localRotation = orgRotation;
            enabled = false;
        }
	}
}
