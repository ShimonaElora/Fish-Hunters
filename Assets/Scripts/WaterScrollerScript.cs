using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScrollerScript : MonoBehaviour {

    public float scrollSpeed;
    private Vector2 savedOffset;
    private float startTime;

    void Start()
    {
        savedOffset = GetComponent<MeshRenderer>().sharedMaterial.GetTextureOffset("_MainTex");
        startTime = 0f;
        
    }

    void Update()
    {
        if (startTime == 0 && BaitSelectionScript.hasStarted)
        {
            startTime = Time.time;
        }
        if (BaitSelectionScript.hasStarted)
        {
            float x = (Time.time - startTime) * - scrollSpeed;
            Vector2 offset = new Vector2(x, savedOffset.y);
            GetComponent<MeshRenderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
        }

        if (GameoverScript.gameover)
        {
            scrollSpeed -= 0.0005f;
        }
    }

    void OnDisable()
    {
        GetComponent<MeshRenderer>().sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
    }
}
