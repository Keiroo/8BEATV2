using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColorChange : MonoBehaviour {
        
    public float Speed = 1.0f;
    public float Brightness = 1.0f;

    private Camera cameraComponent;
    private Color orgColor;
    private float i = 0f;

    private void OnEnable()
    {
        cameraComponent = GetComponent<Camera>();
        orgColor = cameraComponent.backgroundColor;
        i = 0f;
    }

    void Update () {
        cameraComponent.backgroundColor = Color.HSVToRGB(i, Brightness, Brightness);
        if (i < 1f)
        {
            i += Time.deltaTime * Speed;
        }
        else
        {            
            cameraComponent.backgroundColor = orgColor;
            enabled = false;
        }
    }
}
