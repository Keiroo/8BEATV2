using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    public float Duration = 0.0f;
    public float Amount = 0.7f;
    public float Decrease = 1.0f;

    private Transform cameraTransform;
    private Vector3 cameraPos;
    private float localDuration;

    private void Awake()
    {
        cameraTransform = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        cameraPos = cameraTransform.localPosition;
        localDuration = Duration;
    }

    void Update () {
		
        if (localDuration > 0)
        {
            cameraTransform.localPosition = cameraPos + Random.insideUnitSphere * Amount;
            localDuration -= Time.deltaTime * Decrease;
        }
        else
        {
            localDuration = Duration;
            cameraTransform.localPosition = cameraPos;
            enabled = false;
        }
	}
}
