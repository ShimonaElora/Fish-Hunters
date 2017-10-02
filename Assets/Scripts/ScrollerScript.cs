using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollerScript : MonoBehaviour {

    public float scrollSpeed;
    public Transform spawnPoint;
    public bool shouldStop;
    public GameObject parent;
    public float minSpeed;
    private Vector3 transformPosition;
    private float scrollSpeedVariable;
    private bool instanciatedPrevious;

    private void Start()
    {
        if (!BaitSelectionScript.hasStarted)
        {
            scrollSpeedVariable = minSpeed;
        } else
        {
            scrollSpeedVariable = scrollSpeed;
        }
        
        instanciatedPrevious = false;
    }

    void Update()
    {
        if (shouldStop)
        {
            if (BaitSelectionScript.hasStarted && scrollSpeedVariable <= scrollSpeed)
            {
                scrollSpeedVariable += scrollSpeed * 0.01f;
                scrollSpeedVariable = Mathf.Clamp(scrollSpeedVariable, minSpeed, scrollSpeed);
            }

            if (GameoverScript.gameover && scrollSpeedVariable >= minSpeed)
            {
                scrollSpeedVariable -= scrollSpeed * 0.01f;
                scrollSpeedVariable = Mathf.Clamp(scrollSpeedVariable, minSpeed, scrollSpeed);
            }

            transformPosition = new Vector3(transform.position.x + scrollSpeedVariable, transform.position.y, transform.position.z);

            transform.position = transformPosition;
        } 
        else
        {
            transformPosition = new Vector3(transform.position.x + scrollSpeed, transform.position.y, transform.position.z);

            transform.position = transformPosition;
        }

        if (transform.position.x >= 0 && !instanciatedPrevious)
        {
            GameObject clone = Instantiate(gameObject);
            clone.transform.parent = parent.transform;
            clone.transform.position = new Vector3(transform.position.x + spawnPoint.position.x, transform.position.y, transform.position.z);
            instanciatedPrevious = true;
        }

        if (transform.position.x >= 24.7)
        {
            Destroy(gameObject);
        }
    }
    
}
