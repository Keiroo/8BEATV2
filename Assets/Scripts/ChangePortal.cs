using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePortal : MonoBehaviour {

    public Sprite[] sprites;

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
        }
        else if (button.name == "GreenButton")
        {
            GetComponentInChildren<SpriteRenderer>().sprite = sprites[1];
        }
        else if (button.name == "BlueButton")
        {
            GetComponentInChildren<SpriteRenderer>().sprite = sprites[2];
        }
    }
}
