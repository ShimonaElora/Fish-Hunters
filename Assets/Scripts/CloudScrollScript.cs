using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScrollScript : MonoBehaviour {

    public float speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + Time.deltaTime * -speed, transform.position.y);
        if (transform.position.x <= -11.6f)
        {
            Destroy(gameObject);
        }
    }
}
