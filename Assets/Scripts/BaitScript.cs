using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaitScript : MonoBehaviour {

    public Text baitNumber;
    public int initialCount;

	// Use this for initialization
	void Start () {
        baitNumber.text = initialCount.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        baitNumber.text = initialCount.ToString();
        if (initialCount <= 0)
        {
            GetComponent<Collider2D>().enabled = false;
        } else
        {
            GetComponent<Collider2D>().enabled = true;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.name == "bait1(Clone)")
        {
            if ((collision.GetComponent<Collider2D>().gameObject.name == "Fish1L(Clone)" || collision.GetComponent<Collider2D>().gameObject.name == "Fish1R(Clone)") && !collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().touchedBait && !collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().collided)
            {
                collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().touchedBait = true;
                collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().bait = gameObject;
                //initialCount--;
            }
        } else if (gameObject.name == "bait2(Clone)")
        {
            if ((collision.GetComponent<Collider2D>().gameObject.name == "Fish2L(Clone)" || collision.GetComponent<Collider2D>().gameObject.name == "Fish2R(Clone)") && !collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().touchedBait && !collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().collided)
            {
                collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().touchedBait = true;
                collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().bait = gameObject;
                //initialCount--;
            }
        }
        else if (gameObject.name == "bait3(Clone)")
        {
            if ((collision.GetComponent<Collider2D>().gameObject.name == "Fish3L(Clone)" || collision.GetComponent<Collider2D>().gameObject.name == "Fish3R(Clone)") && !collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().touchedBait && !collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().collided)
            {
                collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().touchedBait = true;
                collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().bait = gameObject;
                //initialCount--;
            }
        }
        else if (gameObject.name == "bait4(Clone)")
        {
            if ((collision.GetComponent<Collider2D>().gameObject.name == "Fish4L(Clone)" || collision.GetComponent<Collider2D>().gameObject.name == "Fish4R(Clone)") && !collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().touchedBait && !collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().collided)
            {
                collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().touchedBait = true;
                collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().bait = gameObject;
                //initialCount--;
            }
        }
        else if (gameObject.name == "bait5(Clone)")
        {
            if ((collision.GetComponent<Collider2D>().gameObject.name == "Fish5L(Clone)" || collision.GetComponent<Collider2D>().gameObject.name == "Fish5R(Clone)") && !collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().touchedBait && !collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().collided)
            {
                collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().touchedBait = true;
                collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().bait = gameObject;
                //initialCount--;
            }
        }

    }
}
