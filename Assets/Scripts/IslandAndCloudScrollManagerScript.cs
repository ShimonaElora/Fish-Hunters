using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandAndCloudScrollManagerScript : MonoBehaviour {
    
    public Sprite[] clouds;
    public GameObject cloud;
    public GameObject backLayerObject;
    public Sprite[] backLayerObjects;
    int previousBackLayer;

    public Transform[] cloudSpawnPointRange;
    public Transform backLayerSpawnPoint;

    public float speed;

    public Transform spawnPoint;

    public Sprite[] smallRocks;
    public Sprite[] largeRocks;
    public Sprite[] rocks;
    public Transform[] rockRange;
    public GameObject backRock;

    bool alternate;

    public GameObject island;

    bool generateArea;
    bool generateRocks;
    bool generateCloudsBack;
    bool generateCloudsMid;
    bool generateCloudsFore;

    // Use this for initialization
    void Start()
    {
        //StartCoroutine(cloudGenerator());

        generateArea = true;
        generateRocks = true;
        generateCloudsBack = true;
        generateCloudsMid = true;
        generateCloudsFore = true;

        alternate = true;

        previousBackLayer = -1;
    }

    private void Update()
    {
        if (!GameoverScript.gameover)
        {
            if (generateArea)
            {
                generateArea = false;
                StartCoroutine(backAreaGenerator());
            }
            if (generateRocks)
            {
                generateRocks = false;
                StartCoroutine(spawnIslands());
            }
            if (generateCloudsBack)
            {
                generateCloudsBack = false;
                StartCoroutine(cloudGeneratorBack());
            }
            if (generateCloudsMid)
            {
                generateCloudsMid = false;
                StartCoroutine(cloudGeneratorMid());
            }
            if (generateCloudsFore)
            {
                generateCloudsFore = false;
                StartCoroutine(cloudGeneratorFore());
            }
        }
    }

    IEnumerator cloudGeneratorBack()
    {
        if (BaitSelectionScript.hasStarted)
        {
            float yPos = Random.Range(cloudSpawnPointRange[0].position.y, cloudSpawnPointRange[1].position.y);
            float scale = Random.Range(0.2f, 0.4f);
            float alpha = 0.5f;
            int sortingLayer = SortingLayer.NameToID("BackGround");
            int orderLayer = Random.Range(-1, 2);
            float sp = 0.1f;

            cloud.GetComponent<SpriteRenderer>().sprite = clouds[Random.Range(0, 8)];
            cloud.GetComponent<Transform>().localScale = new Vector3(scale, scale, 1);

            Color c = cloud.GetComponent<SpriteRenderer>().color;
            c.a = alpha;
            cloud.GetComponent<SpriteRenderer>().color = c;
            cloud.GetComponent<SpriteRenderer>().sortingLayerID = sortingLayer;
            cloud.GetComponent<SpriteRenderer>().sortingOrder = orderLayer;

            GameObject cloudInstantiated = Instantiate(cloud, new Vector3(cloudSpawnPointRange[0].position.x, yPos, cloudSpawnPointRange[0].position.z), cloudSpawnPointRange[0].rotation);
            cloudInstantiated.GetComponent<CloudScrollScript>().speed = sp;
            cloudInstantiated.transform.parent = GameObject.Find("Islands and Clouds").transform;
        }

        yield return new WaitForSeconds(Random.Range(120, 180));

        generateCloudsBack = true;
        
    }

    IEnumerator cloudGeneratorMid()
    {
        if (BaitSelectionScript.hasStarted)
        {
            float yPos = Random.Range(cloudSpawnPointRange[2].position.y, cloudSpawnPointRange[3].position.y);
            float scale = Random.Range(0.5f, 0.6f);
            float alpha = 0.7f;
            int sortingLayer = SortingLayer.NameToID("Midground");
            int orderLayer = Random.Range(-1, 2);
            float sp = 0.2f;

            cloud.GetComponent<SpriteRenderer>().sprite = clouds[Random.Range(0, 8)];
            cloud.GetComponent<Transform>().localScale = new Vector3(scale, scale, 1);

            Color c = cloud.GetComponent<SpriteRenderer>().color;
            c.a = alpha;
            cloud.GetComponent<SpriteRenderer>().color = c;
            cloud.GetComponent<SpriteRenderer>().sortingLayerID = sortingLayer;
            cloud.GetComponent<SpriteRenderer>().sortingOrder = orderLayer;

            GameObject cloudInstantiated = Instantiate(cloud, new Vector3(cloudSpawnPointRange[0].position.x, yPos, cloudSpawnPointRange[0].position.z), cloudSpawnPointRange[0].rotation);
            cloudInstantiated.GetComponent<CloudScrollScript>().speed = sp;
            cloudInstantiated.transform.parent = GameObject.Find("Islands and Clouds").transform;
        }

        yield return new WaitForSeconds(Random.Range(30, 60));

        generateCloudsMid = true;
    }

    IEnumerator cloudGeneratorFore()
    {
        if (BaitSelectionScript.hasStarted)
        {
            float yPos = Random.Range(cloudSpawnPointRange[4].position.y, cloudSpawnPointRange[5].position.y);
            float scale = Random.Range(0.7f, 0.8f);
            float alpha = 1f;
            int sortingLayer = SortingLayer.NameToID("Midground");
            int orderLayer = Random.Range(-1, 2);
            float sp = 0.35f;

            cloud.GetComponent<SpriteRenderer>().sprite = clouds[Random.Range(0, 8)];
            cloud.GetComponent<Transform>().localScale = new Vector3(scale, scale, 1);

            Color c = cloud.GetComponent<SpriteRenderer>().color;
            c.a = alpha;
            cloud.GetComponent<SpriteRenderer>().color = c;
            cloud.GetComponent<SpriteRenderer>().sortingLayerID = sortingLayer;
            cloud.GetComponent<SpriteRenderer>().sortingOrder = orderLayer;

            GameObject cloudInstantiated = Instantiate(cloud, new Vector3(cloudSpawnPointRange[0].position.x, yPos, cloudSpawnPointRange[0].position.z), cloudSpawnPointRange[0].rotation);
            cloudInstantiated.GetComponent<CloudScrollScript>().speed = sp;
            cloudInstantiated.transform.parent = GameObject.Find("Islands and Clouds").transform;
        }

        yield return new WaitForSeconds(Random.Range(15, 30));

        generateCloudsFore = true;
    }

    IEnumerator backAreaGenerator()
    {
        yield return new WaitForSeconds(Random.Range(20, 30));
        
        if (BaitSelectionScript.hasStarted)
        {
            if (alternate)
            {
                int number = Random.Range(10, 13);
                int foreNumber = Random.Range(2, 5);
                int afterNumber = Random.Range(2, 5);
                float increment = (rockRange[0].position.y - rockRange[1].position.y) * 0.067f;
                for (int l = 0; l < number; l++)
                {

                    backRock.GetComponent<SpriteRenderer>().sprite = rocks[Random.Range(0, rocks.Length)];
                    backRock.GetComponent<SpriteRenderer>().sortingOrder = l + 2;
                    GameObject instanciatedBackRock = Instantiate(
                        backRock,
                        new Vector3(rockRange[0].position.x, rockRange[1].position.y + increment, rockRange[0].position.z),
                        rockRange[0].rotation
                    );

                    instanciatedBackRock.transform.parent = GameObject.Find("Island Back Spawn Points").transform;

                    if (l < foreNumber)
                    {
                        yield return new WaitForSeconds(Random.Range(10, 15));
                    } else if (l >= number - afterNumber)
                    {
                        yield return new WaitForSeconds(Random.Range(15, 20));
                    } else
                    {
                        yield return new WaitForSeconds(Random.Range(3, 6));
                    }

                }

                yield return new WaitForSeconds(Random.Range(30, 60));
            }
            else
            {
                int backLayerNumber;
                if (previousBackLayer == -1)
                {
                    backLayerNumber = Random.Range(0, 3);
                }
                else
                {
                    if (previousBackLayer == 0)
                    {
                        backLayerNumber = Random.Range(1, 3);
                    }
                    else if (previousBackLayer == 1)
                    {
                        if ((int)Random.Range(0, 2) == 0)
                        {
                            backLayerNumber = 0;
                        }
                        else
                        {
                            backLayerNumber = 2;
                        }
                    }
                    else
                    {
                        backLayerNumber = Random.Range(0, 2);
                    }
                }
                backLayerObject.GetComponent<SpriteRenderer>().sprite = backLayerObjects[backLayerNumber];
                previousBackLayer = backLayerNumber;
                Vector3 backObjectPosition;
                float sp;
                if (backLayerNumber == 0)
                {
                    backObjectPosition = new Vector3(backLayerSpawnPoint.position.x, backLayerSpawnPoint.position.y - 2.43f, backLayerSpawnPoint.position.z);
                    sp = speed / 10;
                }
                else if (backLayerNumber == 1)
                {
                    backObjectPosition = new Vector3(backLayerSpawnPoint.position.x, backLayerSpawnPoint.position.y - 2.49f, backLayerSpawnPoint.position.z);
                    sp = speed / 10;
                }
                else
                {
                    backObjectPosition = new Vector3(backLayerSpawnPoint.position.x, backLayerSpawnPoint.position.y - 2.19f, backLayerSpawnPoint.position.z);
                    sp = speed / 20;
                }

                GameObject backLayerObjectInstantiated = Instantiate(backLayerObject, backObjectPosition, backLayerSpawnPoint.rotation);

                backLayerObjectInstantiated.GetComponent<AreaBackLayerScript>().speed = sp;
                backLayerObjectInstantiated.transform.parent = GameObject.Find("backAreaSpawnPoint").transform;

                if (backLayerNumber == 2)
                {
                    yield return new WaitForSeconds(Random.Range(240, 300));
                }
                else
                {
                    yield return new WaitForSeconds(Random.Range(60, 150));
                }

            }

            alternate = !alternate;
                
        }

        yield return new WaitForSeconds(Random.Range(1, 2));

        generateArea = true;
    }

    IEnumerator spawnIslands()
    {
        yield return new WaitForSeconds(5);

        bool bigRockSpawn = false;
        
        if (BaitSelectionScript.hasStarted)
        {
            if (bigRockSpawn)
            {
                bigRockSpawn = false;

                island.GetComponent<SpriteRenderer>().sprite = largeRocks[Random.Range(0, largeRocks.Length)];
                GameObject islandInstantiated = Instantiate(
                    island,
                    new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z),
                    spawnPoint.rotation
                );
                islandInstantiated.transform.parent = GameObject.Find("backAreaSpawnPoint").transform;
                islandInstantiated.GetComponent<IslandScrollScript>().speed = speed / 5;
            }
            else
            {

                island.GetComponent<SpriteRenderer>().sprite = smallRocks[Random.Range(0, smallRocks.Length)];
                GameObject islandInstantiated = Instantiate(
                    island,
                    new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z),
                    spawnPoint.rotation
                );
                islandInstantiated.transform.parent = GameObject.Find("backAreaSpawnPoint").transform;
                islandInstantiated.GetComponent<IslandScrollScript>().speed = speed / 2;
            }


            if ((int)Random.Range(1, 10) == 7) bigRockSpawn = true;

            yield return new WaitForSeconds(Random.Range(5, 30));
        }

        yield return new WaitForSeconds(Random.Range(1, 2));

        generateRocks = true;
    }
    
}
