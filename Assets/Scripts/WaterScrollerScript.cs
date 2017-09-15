using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScrollerScript : MonoBehaviour {

    public float scrollSpeed;
    private Vector2 savedOffset;
    private float scrollSpeedFinal;

    void Start()
    {
        savedOffset = GetComponent<MeshRenderer>().sharedMaterial.GetTextureOffset("_MainTex");
        scrollSpeedFinal = 0f;
    }

    void Update()
    {
        float x = Mathf.Repeat(Time.time * scrollSpeedFinal, 1);
        Vector2 offset = new Vector2(x, savedOffset.y);
        GetComponent<MeshRenderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);

        if (GameoverScript.gameover && scrollSpeedFinal >= 0f)
        {
            scrollSpeed -= 0.0001f;
        }
    }

    void OnDisable()
    {
        GetComponent<MeshRenderer>().sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
    }
}
