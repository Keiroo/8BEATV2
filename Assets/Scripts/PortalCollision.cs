using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCollision : MonoBehaviour {

    public GameObject GM;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject enemy = collision.gameObject;
        string name = enemy.name;
        string portalName = GetComponent<SpriteRenderer>().sprite.name;

        if ((name == "RedEnemy(Clone)" && portalName == "RedPortal")
            || (name == "BlueEnemy(Clone)" && portalName == "BluePortal")
            || (name == "GreenEnemy(Clone)" && portalName == "GreenPortal"))
        {
            GM.GetComponent<GameManager>().AddPoints();
        }
        else GM.GetComponent<GameManager>().LoseHealthPoint();

        Destroy(enemy);
    }
}
