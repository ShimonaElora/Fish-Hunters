﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().tag == "fish" && collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().touchedBait == true)
        {
            BaitScript.initialCount++;
        }
        if (collision.gameObject.transform.parent)
        {
            Destroy(collision.gameObject.transform.parent.gameObject);
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().tag == "fish" && collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().touchedBait == true)
        {
            BaitScript.initialCount++;
        }
        if (collision.gameObject.transform.parent)
        {
            Destroy(collision.gameObject.transform.parent.gameObject);
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
