using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandScrollScript : MonoBehaviour {

    public float speed;
    float speedVariable;

	// Use this for initialization
	void Start () {
        speedVariable = 0;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x + Time.deltaTime * speedVariable, transform.position.y);
        if (transform.position.x >= 11.6f)
        {
            Destroy(gameObject);
        }

        if (GameoverScript.gameover && speedVariable >= 0f)
        {
            speedVariable -= 0.005f;
        }

        if (BaitSelectionScript.hasStarted && speedVariable <= speed)
        {
            speedVariable += 0.005f;
        }
	}
}
