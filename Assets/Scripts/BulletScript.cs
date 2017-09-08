using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    Transform rightThreshold;

    float offsetX = 0.1f;
    float offsetY;

    bool moveWith = false;

    GameObject fishGameObject;
    Quaternion rotationFish;

    float setXForGravity;

    bool comboStall = false;

    bool collided;

    Transform initialPosition;

    public float gravityFactor;
    float totalGravity;

    // Use this for initialization
    void Start () {
        comboStall = false;
        rightThreshold = GameObject.Find("countMarker").GetComponent<Transform>();
        collided = false;
        initialPosition = transform;
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
            fishGameObject.GetComponent<Collider2D>().isTrigger = true;
            GetComponent<Collider2D>().isTrigger = true;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, GetComponent<Rigidbody2D>().velocity.y * 10f));
            totalGravity = calculateGravityScale(collision.transform) * gravityFactor;
            /*if (collision.transform.position.x < 0 && collision.transform.position.y < 0)
            {
                totalGravity = Mathf.Clamp(totalGravity, 0, 10f);
            } else if (collision.transform.position.x > 0 && collision.transform.position.y < 0)
            {
                totalGravity = Mathf.Clamp(totalGravity, 10f, 30f);
            } else if (collision.transform.position.x < 0 && collision.transform.position.y > 0)
            {
                totalGravity = Mathf.Clamp(totalGravity, 5f, 10f);
            } else
            {
                totalGravity = Mathf.Clamp(totalGravity, 25f, 50f);
            }*/
            
            GetComponent<Rigidbody2D>().gravityScale = totalGravity;
            Debug.Log(totalGravity);
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

    float calculateGravityScale(Transform collisionTransform)
    {
        float xDis = rightThreshold.position.x - collisionTransform.position.x;
        float yDis = collisionTransform.position.y - (-2.5f);

        float gravityScale = gravityFactor * xDis * xDis * yDis * yDis;

        return gravityScale / 100;
    }

}
