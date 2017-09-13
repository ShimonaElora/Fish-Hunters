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

    // Use this for initialization
    void Start () {
        restoreRotation = 0;
        originalRotation = transform.rotation;
        reverse = 7f;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !GameoverScript.gameover)
        {
            touch = Input.GetTouch(0);
            touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = transform.position.z;
            touchPos.x = Mathf.Clamp(touchPos.x, -3.5f, touchPos.x);
            touchPos.y = Mathf.Clamp(touchPos.y, transform.position.y, touchPos.y);

            if (touchPos.x > transform.position.x)
            {
                float angle = Mathf.Atan2((touchPos.y - transform.position.y), (touchPos.x - transform.position.x)) * 45f;
                bulletRotation = Quaternion.AngleAxis(angle, Vector3.forward);
               
                transform.Rotate(Vector3.forward, angle);

                GameObject bullet = (GameObject)Instantiate(Bullet, bulletSpawnPoint.position, bulletRotation);
                bullet.GetComponent<Rigidbody2D>().AddForce(
                    (touchPos - transform.position).normalized * speed, 
                    ForceMode2D.Force
                );
            }
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
            if (angle <= 85f)
            {
                transform.Rotate(Vector3.forward, rotateAngle * rotationFactor(new Ray2D(transform.position, rotationIndicator.position), touchPos));
            }
            reverse -= Time.deltaTime * 20f;
        }
    }

    float rotationFactor(Ray2D ray, Vector2 point)
    {
        return Vector3.Cross(ray.direction, point - ray.origin).magnitude;
    }

}
