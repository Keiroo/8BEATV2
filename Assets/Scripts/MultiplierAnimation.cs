using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierAnimation : MonoBehaviour {

    public float maxScale = 1.5f;
    public float scaleSpeed = 1.0f;
    public float rotation = 90f;

    private Vector3 orgScale;
    private Quaternion orgRotation;
    private float endScale;
    private bool direction;

    

    private void OnEnable()
    {
        direction = true;
        orgScale = transform.localScale;
        orgRotation = transform.localRotation;
        endScale = orgScale.x * maxScale;
    }

    // Update is called once per frame
    void Update () {
		if (direction)
        {
            if (transform.localScale.x < endScale)
            {
                transform.Rotate(0f, 0f, rotation * Time.deltaTime);
                transform.localScale = new Vector3(transform.localScale.x + Time.deltaTime * scaleSpeed,
                                                    transform.localScale.y + Time.deltaTime * scaleSpeed,
                                                    1f);

                
            }
            else
            {
                direction = false;
            }
        }
        else
        {
            transform.Rotate(0f, 0f, 2f * rotation * Time.deltaTime);
            transform.localScale = new Vector3(transform.localScale.x - 2f * Time.deltaTime * scaleSpeed,
                                                    transform.localScale.y - 2f * Time.deltaTime * scaleSpeed,
                                                    1f);

            

            if (transform.localScale.x <= orgScale.x)
            {
                transform.localScale = orgScale;
                transform.localRotation = orgRotation;
                enabled = false;
            }
        }


	}
}
