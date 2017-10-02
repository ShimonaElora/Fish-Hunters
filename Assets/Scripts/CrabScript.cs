using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabScript : MonoBehaviour {

    public Transform[] spawnPoints;
    public GameObject[] crab;
    GameObject[] crabList;
    public float speedVertical;
    public float speedHorizontal;
    HookManagerScript hookManagerScript;
    public GameObject shadow;

	// Use this for initialization
	void Start () {
        hookManagerScript = GameObject.Find("Hook Hanger").GetComponent<HookManagerScript>();
        crabList = new GameObject[hookManagerScript.numberHooks];
        for (int i = 0; i < hookManagerScript.numberHooks; i++)
        {
            crabList[i] = crab[hookManagerScript.baitOrder[i] - 1];
        }
        StartCoroutine(crabWaitCycle());	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator crabWaitCycle ()
    {
        float time = Random.Range(20, 30);
        yield return new WaitForSeconds(0);

        while (!GameoverScript.gameover)
        {
            if (BaitSelectionScript.hasStarted)
            {
                float xPos = Random.Range(spawnPoints[0].position.x, spawnPoints[1].position.x);
                Vector3 spawnPosition = new Vector3(Random.Range(spawnPoints[0].position.x, spawnPoints[1].position.x), spawnPoints[0].position.y, spawnPoints[0].position.z);

                int index = Random.Range(0, hookManagerScript.numberHooks);

                if (hookManagerScript.baitInstantiated[index].GetComponent<BaitScript>().initialCount >= 0)
                {
                    GameObject crabInstantiated = (GameObject)Instantiate(crabList[index], spawnPosition, crabList[index].GetComponent<Transform>().rotation);
                    crabInstantiated.transform.SetParent(transform, false);

                    if (spawnPosition.x <= 0)
                    {
                        crabInstantiated.GetComponent<Rigidbody2D>().AddForce(
                            new Vector2(speedHorizontalMapper(crabInstantiated.transform), 2.6f * speedVertical),
                            ForceMode2D.Force
                        );
                    }
                    else
                    {
                        crabInstantiated.GetComponent<Rigidbody2D>().AddForce(
                            new Vector2(speedHorizontalMapper(crabInstantiated.transform) * -1f, 2.6f * speedVertical),
                            ForceMode2D.Force
                        );
                    }
                }

            }

            yield return new WaitForSeconds(Random.Range(2, 3));
        }
    }

    float speedHorizontalMapper(Transform crabTransform)
    {
        return (3.6f) * (3.6f) * speedHorizontal * 10f;
    }
}
