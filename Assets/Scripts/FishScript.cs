using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour {

    Transform baitSpawnPoint;

	// Use this for initialization
	void Start () {
        baitSpawnPoint = GameObject.Find("baitSpawnPoint").GetComponent<Transform>();
        if (transform.position.x > baitSpawnPoint.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
