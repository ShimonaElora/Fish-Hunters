using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour {

    Transform baitSpawnPoint;
    Vector3 distance;
    public bool touchedBait = false;
    public GameObject bait;
    public bool collided = false;

	// Use this for initialization
	void Start () {
        touchedBait = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (GameoverScript.gameover)
        {
            GetComponent<Collider2D>().enabled = false;
        }
        if (touchedBait)
        {
            for (int i = 0; i < GameObject.Find("Mast, Hooks and Bait").GetComponent<HookManagerScript>().numberHooks; i++)
            {
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.FindGameObjectsWithTag("bait")[i].GetComponent<Collider2D>());
            }
        }
    }

    private void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "bullet")
        {
            collided = true;
        }
    }

}
