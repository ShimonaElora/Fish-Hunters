using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaitScript : MonoBehaviour {

    public Text baitNumber;
    public int initialCount = 10;

	// Use this for initialization
	void Start () {
        baitNumber.text = initialCount.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        baitNumber.text = initialCount.ToString();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().tag == "fish")
        {
            collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().touchedBait = true;
            collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().bait = gameObject;
            initialCount--;
        }
    }
}
