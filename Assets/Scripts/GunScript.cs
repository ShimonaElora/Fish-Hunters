using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {

    public GameObject Bullet;
    public Transform bulletSpawnPoint;
    public Transform rotationIndicator;

    private Touch touch;
    private Vector3 touchPos;

    private int restoreRotation;
    Quaternion originalRotation;
    public Transform markerDown;
    public Transform markerUp;
    float reverse;

    Quaternion bulletRotation;

    public float speed;

    float rotateAngle;

    Quaternion maxAngle;

    // Use this for initialization
    void Start () {
        restoreRotation = 0;
        originalRotation = transform.rotation;
        reverse = 7f;
        maxAngle = transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {

        Debug.DrawLine(transform.position, rotationIndicator.position);

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !GameoverScript.gameover)
        {
            touch = Input.GetTouch(0);
            touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.x = Mathf.Clamp(touchPos.x, -3.5f, touchPos.x);
            touchPos.y = Mathf.Clamp(touchPos.y, transform.position.y, touchPos.y);

            if (touchPos.x > transform.position.x)
            {
                if (touchPos.y >= transform.position.y)
                {
                    restoreRotation = 1;
                    reverse = 4f;
                    rotateAngle = Mathf.Atan( (touchPos.y - transform.position.y)/(touchPos.x - transform.position.x) );
                    //Debug.Log(maxAngle1 + " " + transform.rotation.eulerAngles.magnitude);
                }
                else
                {
                    restoreRotation = 2;
                    reverse = 4f;
                    rotateAngle = - Mathf.Atan((touchPos.y - transform.position.y) / (touchPos.x - transform.position.x));
                    maxAngle = Quaternion.FromToRotation(transform.position, touchPos);
                }

                float angle = Mathf.Atan2((touchPos.y - transform.position.y), (touchPos.x - transform.position.x)) * Mathf.Rad2Deg;
                bulletRotation = Quaternion.AngleAxis(angle, Vector3.forward);

                GameObject bullet = (GameObject)Instantiate(Bullet, bulletSpawnPoint.position, bulletRotation);
                bullet.GetComponent<Rigidbody2D>().AddForce(
                    (touchPos - transform.position).normalized * speed, 
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
            float angle = Quaternion.Angle(originalRotation, transform.rotation);
            if (angle <= 78f)
            {
                transform.Rotate(Vector3.forward, rotateAngle * rotationFactor(new Ray2D(transform.position, rotationIndicator.position), touchPos));
            }
            reverse -= Time.deltaTime * 20f;
        }
        else if (restoreRotation == 2 && reverse > 0)
        {
            float angle = Quaternion.Angle(originalRotation, transform.rotation);
            Debug.Log(angle + " " + rotateAngle + transform.rotation);
            if (angle <= 75f)
            {
                transform.Rotate(Vector3.back, rotateAngle * rotationFactor(new Ray2D(transform.position, rotationIndicator.position), touchPos));
            }
            reverse -= Time.deltaTime * 20f;
        }
    }

    float rotationFactor(Ray2D ray, Vector2 point)
    {
        Debug.Log(Vector3.Cross(ray.direction, point - ray.origin).magnitude);
        return Vector3.Cross(ray.direction, point - ray.origin).magnitude;
    }

}
