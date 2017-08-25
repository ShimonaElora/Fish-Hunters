using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatScript : MonoBehaviour {

    public Transform gunSpawnPoint;

    Rigidbody2D rigidBody2D;

    bool passed = true;

	// Use this for initialization
	void Start () {
        rigidBody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (passed)
        {
            passed = false;
            StartCoroutine(bounce());
        }
	}

    IEnumerator bounce ()
    {
        yield return new WaitForSeconds(5);

        rigidBody2D.AddForceAtPosition(Vector2.up * 500f, gunSpawnPoint.position);

        passed = true;
    }
}
