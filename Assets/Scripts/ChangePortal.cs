using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePortal : MonoBehaviour {

    public Sprite[] sprites;
    public GameObject[] spectrums;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Change(Button button)
    {
        if (button.name == "RedButton")
        {
            GetComponentInChildren<SpriteRenderer>().sprite = sprites[0];
            ChangeSpectrumsColor(new Color(0.2f, 0f, 0f));
        }
        else if (button.name == "GreenButton")
        {
            GetComponentInChildren<SpriteRenderer>().sprite = sprites[1];
            ChangeSpectrumsColor(new Color(0f, 0.2f, 0f));
        }
        else if (button.name == "BlueButton")
        {
            GetComponentInChildren<SpriteRenderer>().sprite = sprites[2];
            ChangeSpectrumsColor(new Color(0f, 0f, 0.2f));
        }
    }

    private void ChangeSpectrumsColor(Color color)
    {
        foreach (GameObject spec in spectrums)
        {
            spec.GetComponent<SimpleSpectrum>().colorMin = color;
            spec.GetComponent<SimpleSpectrum>().RebuildSpectrum();
        }
    }
}
