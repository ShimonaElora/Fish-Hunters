using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {

    public GameObject Bullet;
    public Transform bulletSpawnPoint;

    private Touch touch;
    private Vector3 touchPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Debug.Log("here");
            touch = Input.GetTouch(0);
            touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if (touchPos.y > bulletSpawnPoint.position.x)
            {
                Instantiate(Bullet, bulletSpawnPoint.position, Bullet.GetComponent<Transform>().rotation)
                    .GetComponent<Rigidbody2D>().AddForce(new Vector2((touchPos.x - transform.position.x) * 800f, (touchPos.y - transform.position.y) * 800f), ForceMode2D.Force);
            }
            else
            {
                Instantiate(Bullet, bulletSpawnPoint.position, Bullet.GetComponent<Transform>().rotation)
                    .GetComponent<Rigidbody2D>().AddForce(new Vector2((touchPos.x - transform.position.x) * 800f, (touchPos.y - transform.position.y) * -800f), ForceMode2D.Force);
            }
        }

    }
}
