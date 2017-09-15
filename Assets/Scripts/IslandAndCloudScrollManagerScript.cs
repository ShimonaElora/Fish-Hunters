using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandAndCloudScrollManagerScript : MonoBehaviour {

    public GameObject[] islands;
    public GameObject[] clouds;

    public Transform[] cloudSpawnPointRange;
    public Transform islandSpawnPoint;

    public float speed;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(cloudGenerator());
        StartCoroutine(islandGenerator());
        GameObject.Find("water").GetComponent<WaterScrollerScript>().scrollSpeed = speed * 0.6f / 10;
    }

    IEnumerator cloudGenerator()
    {
        while (!GameoverScript.gameover)
        {
            float yPos = Random.Range(cloudSpawnPointRange[0].position.y, cloudSpawnPointRange[1].position.y);
            Transform cloudPosition = cloudSpawnPointRange[2];
            cloudPosition.position = new Vector3(cloudSpawnPointRange[2].position.x, yPos);

            GameObject cloud = clouds[Random.Range(0, 3)];

            GameObject cloudInstantiated = Instantiate(cloud, cloudPosition);
            cloudInstantiated.GetComponent<CloudScrollScript>().speed = speed / 2;
            cloudInstantiated.transform.parent = GameObject.Find("Islands and Clouds").transform;

            yield return new WaitForSeconds(Random.Range(2, 7));
        }
    }

    IEnumerator islandGenerator()
    {
        while (!GameoverScript.gameover)
        {
            GameObject island = islands[Random.Range(0, 3)];

            GameObject islandInstantiated = Instantiate(island, islandSpawnPoint);
            islandInstantiated.GetComponent<IslandScrollScript>().speed = speed;
            islandInstantiated.transform.parent = GameObject.Find("islandSpawnPoint").transform;

            yield return new WaitForSeconds(Random.Range(5, 10));
        }
    }
}
