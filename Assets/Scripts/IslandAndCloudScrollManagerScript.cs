using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandAndCloudScrollManagerScript : MonoBehaviour {

    public Sprite[] islands;
    public Sprite[] clouds;
    public GameObject cloud;
    public GameObject backLayerObject;
    public Sprite[] backLayerObjects;
    int previousBackLayer;

    public Transform[] cloudSpawnPointRange;
    public Transform backLayerSpawnPoint;

    public float speed;

    public Transform spawnPointBack;
    public Transform spawnPointMid;
    public Transform spawnPointFront;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(cloudGenerator());
        StartCoroutine(islandGenerator());
        GameObject.Find("water").GetComponent<WaterScrollerScript>().scrollSpeed = speed * 0.6f / 10;
        previousBackLayer = -1;
    }

    IEnumerator cloudGenerator()
    {
        while (!GameoverScript.gameover)
        {
            if (BaitSelectionScript.hasStarted)
            {
                float yPos = Random.Range(cloudSpawnPointRange[0].position.y, cloudSpawnPointRange[1].position.y);
                Transform cloudPosition = cloudSpawnPointRange[2];
                cloudPosition.position = new Vector3(cloudSpawnPointRange[2].position.x, yPos);

                cloud.GetComponent<SpriteRenderer>().sprite = clouds[Random.Range(0, 8)];

                GameObject cloudInstantiated = Instantiate(cloud, cloudPosition);
                cloudInstantiated.GetComponent<CloudScrollScript>().speed = speed / 5;
                cloudInstantiated.transform.parent = GameObject.Find("Islands and Clouds").transform;
            }

            yield return new WaitForSeconds(Random.Range(10, 15));
        }
    }

    IEnumerator islandGenerator()
    {
        yield return new WaitForSeconds(Random.Range(20, 30));

        while (!GameoverScript.gameover)
        {
            if (BaitSelectionScript.hasStarted)
            {
                int backLayerNumber;
                if (previousBackLayer == -1)
                {
                    backLayerNumber = Random.Range(0, 3);
                } else
                {
                    if (previousBackLayer == 0)
                    {
                        backLayerNumber = Random.Range(1, 3);
                    } else if (previousBackLayer == 1)
                    {
                        if ((int)Random.Range(0, 2) == 0)
                        {
                            backLayerNumber = 0;
                        } else
                        {
                            backLayerNumber = 2;
                        }
                    } else
                    {
                        backLayerNumber = Random.Range(0, 2);
                    }
                }
                backLayerObject.GetComponent<SpriteRenderer>().sprite = backLayerObjects[backLayerNumber];
                previousBackLayer = backLayerNumber;
                Vector3 backObjectPosition;
                if (backLayerNumber == 0)
                {
                    backObjectPosition = new Vector3(backLayerSpawnPoint.position.x, backLayerSpawnPoint.position.y - 2.31f, backLayerSpawnPoint.position.z);
                } else if (backLayerNumber == 1)
                {
                    backObjectPosition = new Vector3(backLayerSpawnPoint.position.x, backLayerSpawnPoint.position.y - 2f, backLayerSpawnPoint.position.z);
                } else
                {
                    backObjectPosition = new Vector3(backLayerSpawnPoint.position.x, backLayerSpawnPoint.position.y - 1.96f, backLayerSpawnPoint.position.z);
                }

                GameObject backLayerObjectInstantiated = Instantiate(backLayerObject, backObjectPosition, backLayerSpawnPoint.rotation);
                
                backLayerObjectInstantiated.GetComponent<AreaBackLayerScript>().speed = speed / 8;
                backLayerObjectInstantiated.transform.parent = GameObject.Find("backAreaSpawnPoint").transform;
                backLayerObjectInstantiated.GetComponent<AreaBackLayerScript>().type = backLayerNumber;
                backLayerObjectInstantiated.GetComponent<AreaBackLayerScript>().spawnPointBack = spawnPointBack;
                backLayerObjectInstantiated.GetComponent<AreaBackLayerScript>().spawnPointMid = spawnPointMid;
                backLayerObjectInstantiated.GetComponent<AreaBackLayerScript>().spawnPointFront = spawnPointFront;

                yield return new WaitForSeconds(Random.Range(60, 150));
            }

            yield return new WaitForSeconds(Random.Range(1, 2));
        }
    }
}
