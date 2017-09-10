using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScrollerScript : MonoBehaviour {

    public float scrollSpeed;
    private Vector2 savedOffset;

    void Start()
    {
        savedOffset = GetComponent<MeshRenderer>().sharedMaterial.GetTextureOffset("_MainTex");
    }

    void Update()
    {
        float x = Mathf.Repeat(Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2(x, savedOffset.y);
        GetComponent<MeshRenderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

    void OnDisable()
    {
        GetComponent<MeshRenderer>().sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
    }
}
