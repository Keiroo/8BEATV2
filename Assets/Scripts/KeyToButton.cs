using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyToButton : MonoBehaviour {

    public KeyCode keyCode;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(keyCode))
        {
            GetComponent<Button>().onClick.Invoke();
        }
	}
}
