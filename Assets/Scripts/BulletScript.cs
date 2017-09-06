using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    float offsetX = 1f;
    float offsetY;

    bool moveWith = false;

    GameObject fishGameObject;
    Quaternion rotationFish;

    float setXForGravity;

	// Use this for initialization
	void Start () {
		


	}
	
	// Update is called once per frame
	void Update () {
		
        if (moveWith && fishGameObject != null)
        {
            fishGameObject.GetComponent<Transform>().position = new Vector3 (
                transform.position.x + offsetX, 
                transform.position.y, 
                fishGameObject.GetComponent<Transform>().position.z
            );
            fishGameObject.GetComponent<Transform>().rotation = rotationFish;
        }

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "fish")
        {
            fishGameObject = collision.collider.gameObject;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.gravityScale = 20f;
            rb.drag = 4f;
            rotationFish = fishGameObject.GetComponent<Transform>().rotation;
            fishGameObject.GetComponent<Collider2D>().isTrigger = true;
            GetComponent<Collider2D>().isTrigger = true;
            moveWith = true;
        }
    }

    public void ParameterSetup (float posX)
    {
        setXForGravity = posX;
    }
}
