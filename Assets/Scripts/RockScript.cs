using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x + Time.deltaTime * -speed, transform.position.y);
        if (transform.position.x <= -11.6f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().gameObject.tag == "canon fire")
        {
            Destroy(gameObject);
        }
        else if (collision.GetComponent<Collider2D>().gameObject.name == "Boat")
        {
            GameoverScript.gameover = true;
        }
    }
}
