using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour {

    public Material material;

    float r, g, b;

	// Use this for initialization
	void Start () {
        material.color = new Color(1, 1, 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
        /*Debug.Log(material.color);
        r = material.color.r;
        g = material.color.g;
        b = material.color.b;
        r -= 0.01f;
        g -= 0.01f;
        b -= 0.01f;
        r = Mathf.Clamp((float)r, 0.5f, 1f);
        g = Mathf.Clamp((float)g, 0.5f, 1f);
        b = Mathf.Clamp((float)b, 0.5f, 1f);
        material.color = new Color(r, g, b, material.color.a);*/
	}
}
