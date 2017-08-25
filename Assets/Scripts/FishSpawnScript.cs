using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawnScript : MonoBehaviour {

    public Transform[] foreSpawnPoints;
    public Transform[] midSpawnPoints;
    public Transform[] backSpawnPoints;

    public Transform baitSpawnPoint;

    public GameObject Fish;

    float speed = 15f;

    private bool startWaitBool = true;
    private bool startForeBool = true;
    private bool startMidBool = true;
    private bool startBackBool = true;

    private int time;

	// Use this for initialization
	void Start () {
        StartCoroutine(startWait());
	}
	
	// Update is called once per frame
	void Update () {

        if (!startWaitBool)
        {
            if (startForeBool)
            {
                startForeBool = false;
                StartCoroutine(foreGroundFish());
            }
            if (startMidBool)
            {
                startMidBool = false;
                StartCoroutine(midGroundFish());
            }
            if (startBackBool)
            {
                startBackBool = false;
                StartCoroutine(backGroundFish());
            }
        }
		
	}

    IEnumerator startWait()
    {
        yield return new WaitForSeconds(5);

        startWaitBool = false;
    }

    IEnumerator foreGroundFish ()
    {
        time = Random.Range(2, 5);
        yield return new WaitForSeconds(time);

        Transform spawnPoint = foreSpawnPoints[Random.Range(0, 5)];

        Vector3 spawnPosition = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);

        if (spawnPosition.x < baitSpawnPoint.position.x)
        {
            Instantiate(Fish, spawnPosition, Fish.GetComponent<Transform>().rotation)
                .GetComponent<Rigidbody2D>().AddForce(new Vector2((baitSpawnPoint.position.x - transform.position.x) * 500f, (baitSpawnPoint.position.y - transform.position.y) * 1000f), ForceMode2D.Force);
        } else
        {
            Instantiate(Fish, spawnPosition, Fish.GetComponent<Transform>().rotation)
               .GetComponent<Rigidbody2D>().AddForce(new Vector2( (baitSpawnPoint.position.x - transform.position.x) * -500f, (baitSpawnPoint.position.y - transform.position.y) * 1000f), ForceMode2D.Force);
        }

        startForeBool = true;
    }

    IEnumerator midGroundFish()
    {
        time = Random.Range(3, 6);
        yield return new WaitForSeconds(time);

        Transform spawnPoint = midSpawnPoints[Random.Range(0, 5)];

        Vector3 spawnPosition = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);

        if (spawnPosition.x < baitSpawnPoint.position.x)
        {
            Instantiate(Fish, spawnPosition, Fish.GetComponent<Transform>().rotation)
                .GetComponent<Rigidbody2D>().AddForce(new Vector2((baitSpawnPoint.position.x - transform.position.x) * 500f, (baitSpawnPoint.position.y - transform.position.y) * 1000f), ForceMode2D.Force);
        }
        else
        {
            Instantiate(Fish, spawnPosition, Fish.GetComponent<Transform>().rotation)
               .GetComponent<Rigidbody2D>().AddForce(new Vector2((baitSpawnPoint.position.x - transform.position.x) * -500f, (baitSpawnPoint.position.y - transform.position.y) * 1000f), ForceMode2D.Force);
        }

        startMidBool = true;
    }

    IEnumerator backGroundFish()
    {
        time = Random.Range(4, 7);
        yield return new WaitForSeconds(time);

        Transform spawnPoint = backSpawnPoints[Random.Range(0, 5)];

        Vector3 spawnPosition = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);

        if (spawnPosition.x < baitSpawnPoint.position.x)
        {
            Instantiate(Fish, spawnPosition, Fish.GetComponent<Transform>().rotation)
                .GetComponent<Rigidbody2D>().AddForce(new Vector2((baitSpawnPoint.position.x - transform.position.x) * 500f, (baitSpawnPoint.position.y - transform.position.y) * 1000f), ForceMode2D.Force);
        }
        else
        {
            Instantiate(Fish, spawnPosition, Fish.GetComponent<Transform>().rotation)
               .GetComponent<Rigidbody2D>().AddForce(new Vector2((baitSpawnPoint.position.x - transform.position.x) * -500f, (baitSpawnPoint.position.y - transform.position.y) * 1000f), ForceMode2D.Force);
        }

        startBackBool = true;
    }
}
