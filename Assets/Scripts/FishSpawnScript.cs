using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawnScript : MonoBehaviour {

    public Transform[] foreSpawnPoints;
    public Transform[] midSpawnPoints;
    public Transform[] backSpawnPoints;
    public GameObject shadow;

    public Transform baitSpawnPoint;

    public GameObject[] Fish;

    float speedHorizontal = 400f;
    public float speedVertical;
    public float gravityScale;

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

        speedVertical = 500 * (3 + gravityScale) / 6f;

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

        Instantiate(shadow, spawnPosition, shadow.GetComponent<Transform>().rotation);

        yield return new WaitForSeconds(1);

        if (spawnPosition.x < baitSpawnPoint.position.x)
        {
            GameObject fish = (GameObject) Instantiate(Fish[0], spawnPosition, Fish[0].GetComponent<Transform>().rotation);
            fish.GetComponent<Rigidbody2D>().AddForce(
                new Vector2((baitSpawnPoint.position.x - transform.position.x) * speedHorizontal, 2.7f * speedVertical),
                ForceMode2D.Force
            );
            fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
        } else
        {
            GameObject fish = (GameObject)Instantiate(Fish[1], spawnPosition, Fish[1].GetComponent<Transform>().rotation);
            fish.GetComponent<Rigidbody2D>().AddForce(
                new Vector2((baitSpawnPoint.position.x - transform.position.x) * - speedHorizontal, 2.7f * speedVertical),
                ForceMode2D.Force
            );
            fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
        }

        startForeBool = true;
    }

    IEnumerator midGroundFish()
    {
        time = Random.Range(3, 6);
        yield return new WaitForSeconds(time);

        Transform spawnPoint = midSpawnPoints[Random.Range(0, 5)];

        Vector3 spawnPosition = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);

        Instantiate(shadow, spawnPosition, shadow.GetComponent<Transform>().rotation);

        yield return new WaitForSeconds(1);

        if (spawnPosition.x < baitSpawnPoint.position.x)
        {
            GameObject fish = (GameObject)Instantiate(Fish[0], spawnPosition, Fish[0].GetComponent<Transform>().rotation);
            fish.GetComponent<Rigidbody2D>().AddForce(
                new Vector2((baitSpawnPoint.position.x - transform.position.x) * speedHorizontal, 2.7f * speedVertical),
                ForceMode2D.Force
            );
            fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
        }
        else
        {
            GameObject fish = (GameObject)Instantiate(Fish[1], spawnPosition, Fish[1].GetComponent<Transform>().rotation);
            fish.GetComponent<Rigidbody2D>().AddForce(
                new Vector2((baitSpawnPoint.position.x - transform.position.x) * - speedHorizontal, 2.7f * speedVertical),
                ForceMode2D.Force
            );
            fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
        }

        startMidBool = true;
    }

    IEnumerator backGroundFish()
    {
        time = Random.Range(4, 7);
        yield return new WaitForSeconds(time);

        Transform spawnPoint = backSpawnPoints[Random.Range(0, 5)];

        Vector3 spawnPosition = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);

        Instantiate(shadow, spawnPosition, shadow.GetComponent<Transform>().rotation);

        yield return new WaitForSeconds(1);

        if (spawnPosition.x < baitSpawnPoint.position.x)
        {
            GameObject fish = (GameObject)Instantiate(Fish[0], spawnPosition, Fish[0].GetComponent<Transform>().rotation);
            fish.GetComponent<Rigidbody2D>().AddForce(
                new Vector2((baitSpawnPoint.position.x - transform.position.x) * speedHorizontal, 2.7f * speedVertical),
                ForceMode2D.Force
            );
            fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
        }
        else
        {
            GameObject fish = (GameObject)Instantiate(Fish[1], spawnPosition, Fish[1].GetComponent<Transform>().rotation);
            fish.GetComponent<Rigidbody2D>().AddForce(
                new Vector2((baitSpawnPoint.position.x - transform.position.x) * - speedHorizontal, 2.7f * speedVertical),
                ForceMode2D.Force
            );
            fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
        }

        startBackBool = true;
    }
}
