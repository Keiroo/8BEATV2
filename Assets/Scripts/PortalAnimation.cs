using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalAnimation : MonoBehaviour {

    public float PositionCoeff = 1.3f;
    public float Speed = 1.0f;

    private Vector3 orgPosition;
    private float maxPosition;
    private bool direction;
    

    private void OnEnable()
    {
        orgPosition = transform.localPosition;
        maxPosition = orgPosition.y * PositionCoeff;
        direction = true;
    }

    // Update is called once per frame
    void Update () {
		
        if (direction)
        {
            if (transform.localPosition.y > maxPosition)
            {
                transform.localPosition = new Vector3(transform.localPosition.x,
                                                      transform.localPosition.y - Time.deltaTime * Speed,
                                                      transform.localPosition.z);
            }
            else
            {
                direction = false;
            }
        }
        else
        {
            if (transform.localPosition.y < orgPosition.y)
            {
                transform.localPosition = new Vector3(transform.localPosition.x,
                                                      transform.localPosition.y + Time.deltaTime * Speed,
                                                      transform.localPosition.z);
            }
            else
            {
                transform.localPosition = orgPosition;
                enabled = false;
            }
        }
	}
}
