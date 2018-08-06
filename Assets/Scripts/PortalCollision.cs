using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCollision : MonoBehaviour {

    public GameObject GM;
    public GameObject particle;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // for audio debugging
        GM.GetComponent<GameManager>().PrintAudioTimer();

        GameObject enemy = collision.gameObject;
        string name = enemy.name;
        string portalName = GetComponent<SpriteRenderer>().sprite.name;

        

        if ((name == "RedEnemy(Clone)" && portalName == "RedPortal")
            || (name == "BlueEnemy(Clone)" && portalName == "BluePortal")
            || (name == "GreenEnemy(Clone)" && portalName == "GreenPortal")
            || GM.GetComponent<GameManager>().GetDevMode())
        {
            GM.GetComponent<GameManager>().AddPoints();

            gameObject.GetComponent<PortalAnimation>().enabled = true;
            ParticleSystemRenderer renderer = particle.GetComponent<ParticleSystemRenderer>();
            Material mat = renderer.material;

            if (portalName == "RedPortal")
            {
                mat.color = Color.red;
            }
            else if (portalName == "GreenPortal")
            {
                mat.color = Color.green;
            }
            else
            {
                mat.color = Color.blue;
            }

            particle.GetComponent<ParticleSystem>().Play();
        }
        else GM.GetComponent<GameManager>().LoseHealthPoint();

        Destroy(enemy);
    }
}
