using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    Transform rightThreshold;

    private Transform collisionPoint;

    bool moveWith = false;

    GameObject fishGameObject;
    Quaternion rotationFish;

    float setXForGravity;

    bool comboStall = false;

    bool collided;
    
    float totalGravity;

    // Use this for initialization
    void Start () {
        comboStall = false;
        rightThreshold = GameObject.Find("countMarker").GetComponent<Transform>();
        collided = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (comboStall && collided)
        {
            if (transform.position.x > rightThreshold.position.x && ComboScript.comboActive)
            {
                comboStall = false;
                ComboScript.comboNumber++;
            }
        }
        if (ComboScript.comboActive && !collided && (transform.position.x > rightThreshold.position.x || transform.position.y >= 5.1f || transform.position.y <=-5.1f))
        {
            ComboScript.comboActive = false;
            ComboScript.comboNumber = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "fish")
        {
            fishGameObject = collision.collider.gameObject;
            rotationFish = transform.rotation;
            GetComponent<Collider2D>().isTrigger = true;
            fishGameObject.GetComponent<Collider2D>().isTrigger = true;
            collisionPoint = collision.transform;
            projectile();
            collided = true;
            moveWith = true;
            if (ComboScript.comboActive && comboStall)
            {
                comboStall = false;
                ComboScript.comboActive = false;
                ComboScript.comboNumber = 0;
            }
            if (ComboScript.comboActive && !comboStall)
            {
                comboStall = true;
            }
            if (!ComboScript.comboActive)
            {
                ComboScript.comboActive = true;
                ComboScript.comboNumber = 0;
                comboStall = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (moveWith)
        {
            fishGameObject.GetComponent<Transform>().position = new Vector3(
                transform.position.x,
                transform.position.y,
                fishGameObject.GetComponent<Transform>().position.z
            );
            fishGameObject.GetComponent<Transform>().rotation = Quaternion.Inverse(rotationFish);
        }
    }

    public void ParameterSetup (float posX)
    {
        setXForGravity = posX;
    }

    void projectile()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        float velY;
        float velX;
        if (collisionPoint.position.y >= 2f)
        {
            velY = 8f;
            velX = 18f;
        } else
        {
            velY = Mathf.Clamp(30f * (3.43f - collisionPoint.position.y), 8f, 15f);
            velX = Mathf.Clamp(30f * (3.43f - collisionPoint.position.y), 18f, 18f);
        }

        Debug.Log(velY);
        rb.velocity = rb.velocity.normalized + new Vector2(velX, velY);
        rb.gravityScale = 4f;
    }
}
