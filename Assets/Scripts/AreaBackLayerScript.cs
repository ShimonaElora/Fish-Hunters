using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaBackLayerScript : MonoBehaviour {

    public float speed;
    public int type;

    public Transform spawnPointBack;
    public Transform spawnPointMid;
    public Transform spawnPointFront;

    public Sprite[] islands;
    public Sprite[] rocks;
    public Sprite[] archRocks;
    public GameObject[] frontObjects;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(spawnBackIslands());
        StartCoroutine(spawnFrontislands());
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
            speed -= 0.0001f;
        }
    }

    IEnumerator spawnBackIslands()
    {
        yield return new WaitForSeconds(5);

        while (!GameoverScript.gameover && transform.position.x <= 10f)
        {
            if (BaitSelectionScript.hasStarted)
            {
                if (type == 0)
                {
                    frontObjects[0].GetComponent<SpriteRenderer>().sprite = archRocks[Random.Range(0, 13)];
                    GameObject islandBackInstantiated = Instantiate(
                        frontObjects[0],
                        new Vector3(spawnPointBack.position.x, Random.Range(spawnPointMid.position.y, spawnPointBack.position.y), spawnPointBack.position.z),
                        spawnPointBack.rotation
                    );
                    islandBackInstantiated.transform.parent = GameObject.Find("backAreaSpawnPoint").transform;
                    islandBackInstantiated.GetComponent<IslandScrollScript>().speed = speed * 2;
                } else if (type == 1)
                {
                    frontObjects[0].GetComponent<SpriteRenderer>().sprite = islands[Random.Range(0, 6)];
                    GameObject islandBackInstantiated = Instantiate(
                        frontObjects[0],
                        new Vector3(spawnPointBack.position.x, Random.Range(spawnPointMid.position.y, spawnPointBack.position.y), spawnPointBack.position.z),
                        spawnPointBack.rotation
                    );
                    islandBackInstantiated.transform.parent = GameObject.Find("backAreaSpawnPoint").transform;
                    islandBackInstantiated.GetComponent<IslandScrollScript>().speed = speed * 2;
                } else
                {
                    frontObjects[0].GetComponent<SpriteRenderer>().sprite = rocks[Random.Range(0, 13)];
                    GameObject islandBackInstantiated = Instantiate(
                        frontObjects[0],
                        new Vector3(spawnPointBack.position.x, Random.Range(spawnPointMid.position.y, spawnPointBack.position.y), spawnPointBack.position.z),
                        spawnPointBack.rotation
                    );
                    islandBackInstantiated.transform.parent = GameObject.Find("backAreaSpawnPoint").transform;
                    islandBackInstantiated.GetComponent<IslandScrollScript>().speed = speed * 2;
                }

                yield return new WaitForSeconds(Random.Range(5, 10));
            }
        }
    }

    IEnumerator spawnFrontislands()
    {
        yield return new WaitForSeconds(1);

        while (!GameoverScript.gameover)
        {
            if (BaitSelectionScript.hasStarted)
            {
                if (type == 0)
                {
                    frontObjects[1].GetComponent<SpriteRenderer>().sprite = archRocks[Random.Range(0, 13)];
                    GameObject islandFrontInstantiated = Instantiate(
                        frontObjects[1],
                        new Vector3(spawnPointBack.position.x, Random.Range(spawnPointFront.position.y, spawnPointMid.position.y), spawnPointBack.position.z),
                        spawnPointFront.rotation
                    );
                    islandFrontInstantiated.transform.parent = GameObject.Find("backAreaSpawnPoint").transform;
                    islandFrontInstantiated.GetComponent<IslandScrollScript>().speed = speed * 4;
                }
                else if (type == 1)
                {
                    frontObjects[1].GetComponent<SpriteRenderer>().sprite = islands[Random.Range(0, 6)];
                    GameObject islandFrontInstantiated = Instantiate(
                        frontObjects[1],
                        new Vector3(spawnPointBack.position.x, Random.Range(spawnPointFront.position.y, spawnPointMid.position.y), spawnPointBack.position.z),
                        spawnPointFront.rotation
                    );
                    islandFrontInstantiated.transform.parent = GameObject.Find("backAreaSpawnPoint").transform;
                    islandFrontInstantiated.GetComponent<IslandScrollScript>().speed = speed * 4;
                }
                else
                {
                    frontObjects[1].GetComponent<SpriteRenderer>().sprite = rocks[Random.Range(0, 13)];
                    GameObject islandFrontInstantiated = Instantiate(
                        frontObjects[1],
                        new Vector3(spawnPointBack.position.x, Random.Range(spawnPointFront.position.y, spawnPointMid.position.y), spawnPointBack.position.z),
                        spawnPointFront.rotation
                    );
                    islandFrontInstantiated.transform.parent = GameObject.Find("backAreaSpawnPoint").transform;
                    islandFrontInstantiated.GetComponent<IslandScrollScript>().speed = speed * 4;
                }
            }

            yield return new WaitForSeconds(Random.Range(3, 7));
        }
    }
}
