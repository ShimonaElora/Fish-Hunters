﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AreaBackLayerScript : MonoBehaviour {

    public float speed;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + Time.deltaTime * speed, transform.position.y);
        if (transform.position.x >= 13f)
        {
            Destroy(gameObject);
        }

        if (GameoverScript.gameover && speed >= 0f)
        {
            speed -= 0.001f;
        }
    }

}