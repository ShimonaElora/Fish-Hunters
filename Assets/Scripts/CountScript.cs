using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountScript : MonoBehaviour {

    int count = 0;

    public Text countScore;

    GameObject fish;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        countScore.text = count.ToString();

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().tag == "fish" && collision.GetComponent<Collider2D>().gameObject != fish)
        {
            count++;
            fish = collision.GetComponent<Collider2D>().gameObject;
        }
        if (collision.GetComponent<Collider2D>().tag == "fish" && collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().touchedBait)
        {
            collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().bait.GetComponent<BaitScript>().initialCount++;
        }
    }
}
