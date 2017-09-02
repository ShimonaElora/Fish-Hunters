using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {

    public GameObject Bullet;
    public Transform bulletSpawnPoint;

    private Touch touch;
    private Vector3 touchPos;

    private int restoreRotation;
    Quaternion originalRotation;
    public Transform markerDown;
    public Transform markerUp;
    float reverse;

    Quaternion bulletRotation;

    float rotateAngle;

    // Use this for initialization
    void Start () {
        restoreRotation = 0;
        originalRotation = transform.rotation;
        reverse = 7f;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touch = Input.GetTouch(0);
            touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if (touchPos.x > transform.position.x)
            {
                if (touchPos.y >= transform.position.y)
                {
                    restoreRotation = 1;
                    reverse = 4f;
                    rotateAngle = touchPos.y - transform.position.y;
                }
                else
                {
                    restoreRotation = 2;
                    reverse = 4f;
                    rotateAngle = transform.position.y - touchPos.y;
                }
                
                bulletRotation = new Quaternion( 0, 0, -transform.rotation.z * 2, 4f);

                GameObject bullet = (GameObject)Instantiate(Bullet, bulletSpawnPoint.position, bulletRotation);
                bullet.GetComponent<Rigidbody2D>().AddForce(
                    new Vector2((touchPos.x - transform.position.x), 0).normalized * 6500f + new Vector2(0, (touchPos.y - transform.position.y) * 900f), 
                    ForceMode2D.Force
                );
                bullet.GetComponent<BulletScript>().ParameterSetup(touchPos.x);
            }
            //transform.position = new Vector3(transform.position.x, touchPos.y, transform.position.z);
        }

        if (reverse <= 1.2f)
        {
            restoreRotation = 0;
            reverse = 4f;
        }

    }

    private void FixedUpdate()
    {
        if (restoreRotation == 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, Time.deltaTime * 5f);
        }
        else if (restoreRotation == 1 && reverse > 0)
        {
            float angle = Quaternion.Angle(transform.rotation, markerDown.rotation);
            Debug.Log(angle + " " + rotateAngle);
            if (rotateAngle <= angle)
            {
                transform.Rotate(Vector3.forward, rotateAngle * 0.7f);
            }
            reverse -= Time.deltaTime * 30f;
        }
        else if (restoreRotation == 2 && reverse > 0)
        {
            float angle = Quaternion.Angle(transform.rotation, markerUp.rotation);
            if (rotateAngle <= angle)
            {
                transform.Rotate(Vector3.back, rotateAngle * 1.2f);
            }
            reverse -= Time.deltaTime * 30f;
        }
    }

}
