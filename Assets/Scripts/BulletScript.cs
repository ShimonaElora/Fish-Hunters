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

        if (transform.position.x > setXForGravity)
        {
            GetComponent<Rigidbody2D>().gravityScale = 5f;
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "fish")
        {
            fishGameObject = collision.collider.gameObject;
            rotationFish = fishGameObject.GetComponent<Transform>().rotation;
            moveWith = true;
        }
    }

    public void ParameterSetup (float posX)
    {
        setXForGravity = posX;
    }
}
