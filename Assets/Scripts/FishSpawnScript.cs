using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawnScript : MonoBehaviour {

    public Transform[] spawnPoints;
    public GameObject shadow;

    public Transform baitSpawnPoint;

    public GameObject[] Fish;

    public float speedHorizontal = 400f;
    public float speedVertical;
    public float gravityScale;

    private bool startFourthBool = false;
    private bool startFirstBool = false;
    private bool startSecondBool = false;
    private bool startThirdBool = false;

    private int time;

    public bool[] activeBool = new bool[4];

	// Use this for initialization
	void Start () {
        activeBool = new bool[4];
        StartCoroutine(startWait());
        transform.position = new Vector3 (baitSpawnPoint.position.x, transform.position.y, transform.position.z);
        activeBool[0] = false;
        activeBool[1] = false;
        activeBool[2] = false;
        activeBool[3] = false;
	}
	
	// Update is called once per frame
	void Update () {

        //speedVertical = 500 * (3 + gravityScale) / 6f;

        if (!GameoverScript.gameover)
        {
            if (startFirstBool && activeBool[0])
            {
                startFirstBool = false;
                activeBool[0] = false;
                StartCoroutine(foreGroundFish());
            }
            if (startSecondBool && activeBool[1])
            {
                startSecondBool = false;
                activeBool[0] = false;
                StartCoroutine(midGroundFish());
            }
            if (startThirdBool && activeBool[2])
            {
                startThirdBool = false;
                activeBool[0] = false;
                StartCoroutine(backGroundFish());
            }
            if (startFourthBool && activeBool[3])
            {
                startFourthBool = false;
                activeBool[0] = false;
                StartCoroutine(extraFish());
            }
        }
    }

    IEnumerator startWait()
    {
        startFirstBool = true;

        yield return new WaitForSeconds(2);
        startSecondBool = true;

        yield return new WaitForSeconds(60);
        startThirdBool = true;

        yield return new WaitForSeconds(150);
        startFourthBool = true;
    }

    IEnumerator foreGroundFish ()
    {
        time = Random.Range(2, 5);
        yield return new WaitForSeconds(time);

        Vector3 spawnPosition = new Vector3(Random.Range(spawnPoints[0].position.x, spawnPoints[1].position.x), spawnPoints[0].position.y, spawnPoints[0].position.z);

        Instantiate(shadow, spawnPosition, shadow.GetComponent<Transform>().rotation);

        yield return new WaitForSeconds(1);
        Debug.Log((baitSpawnPoint.position.x - transform.position.x));
        if (spawnPosition.x <= baitSpawnPoint.position.x)
        {
            GameObject fish = (GameObject) Instantiate(Fish[1], spawnPosition, Fish[1].GetComponent<Transform>().rotation);
            fish.GetComponent<Rigidbody2D>().AddForce(
                new Vector2(speedHorizontalMapper(fish.transform), 2.7f * speedVertical),
                ForceMode2D.Force
            );
            fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
        } else
        {
            GameObject fish = (GameObject)Instantiate(Fish[0], spawnPosition, Fish[0].GetComponent<Transform>().rotation);
            fish.GetComponent<Rigidbody2D>().AddForce(
                new Vector2(speedHorizontalMapper(fish.transform) * -1f, 2.7f * speedVertical),
                ForceMode2D.Force
            );
            fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
        }

        startFirstBool = true;
        HookManagerScript.nextFish = true;
    }

    IEnumerator midGroundFish()
    {
        time = Random.Range(3, 6);
        yield return new WaitForSeconds(time);

        Vector3 spawnPosition = new Vector3(Random.Range(spawnPoints[0].position.x, spawnPoints[1].position.x), spawnPoints[0].position.y, spawnPoints[0].position.z);

        Instantiate(shadow, spawnPosition, shadow.GetComponent<Transform>().rotation);

        yield return new WaitForSeconds(1);

        if (spawnPosition.x <= baitSpawnPoint.position.x)
        {
            GameObject fish = (GameObject)Instantiate(Fish[1], spawnPosition, Fish[1].GetComponent<Transform>().rotation);
            fish.GetComponent<Rigidbody2D>().AddForce(
                new Vector2(speedHorizontalMapper(fish.transform), 2.7f * speedVertical),
                ForceMode2D.Force
            );
            fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
        }
        else
        {
            GameObject fish = (GameObject)Instantiate(Fish[0], spawnPosition, Fish[0].GetComponent<Transform>().rotation);
            fish.GetComponent<Rigidbody2D>().AddForce(
                new Vector2(speedHorizontalMapper(fish.transform) * -1f, 2.7f * speedVertical),
                ForceMode2D.Force
            );
            fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
        }

        startSecondBool = true;
        HookManagerScript.nextFish = true;
    }

    IEnumerator backGroundFish()
    {
        time = Random.Range(4, 7);
        yield return new WaitForSeconds(time);

        Vector3 spawnPosition = new Vector3(Random.Range(spawnPoints[0].position.x, spawnPoints[1].position.x), spawnPoints[0].position.y, spawnPoints[0].position.z);

        Instantiate(shadow, spawnPosition, shadow.GetComponent<Transform>().rotation);

        yield return new WaitForSeconds(1);

        if (spawnPosition.x <= baitSpawnPoint.position.x)
        {
            GameObject fish = (GameObject)Instantiate(Fish[1], spawnPosition, Fish[1].GetComponent<Transform>().rotation);
            fish.GetComponent<Rigidbody2D>().AddForce(
                new Vector2(speedHorizontalMapper(fish.transform), 2.7f * speedVertical),
                ForceMode2D.Force
            );
            fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
        }
        else
        {
            GameObject fish = (GameObject)Instantiate(Fish[0], spawnPosition, Fish[0].GetComponent<Transform>().rotation);
            fish.GetComponent<Rigidbody2D>().AddForce(
                new Vector2(speedHorizontalMapper(fish.transform) * -1f, 2.7f * speedVertical),
                ForceMode2D.Force
            );
            fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
        }

        startThirdBool = true;
        HookManagerScript.nextFish = true;
    }

    IEnumerator extraFish()
    {
        time = Random.Range(5, 10);
        yield return new WaitForSeconds(time);

        Vector3 spawnPosition = new Vector3(Random.Range(spawnPoints[0].position.x, spawnPoints[1].position.x), spawnPoints[0].position.y, spawnPoints[0].position.z);

        Instantiate(shadow, spawnPosition, shadow.GetComponent<Transform>().rotation);

        yield return new WaitForSeconds(1);
        Debug.Log((baitSpawnPoint.position.x - transform.position.x));

        if (spawnPosition.x <= baitSpawnPoint.position.x)
        {
            GameObject fish = (GameObject)Instantiate(Fish[1], spawnPosition, Fish[1].GetComponent<Transform>().rotation);
            fish.GetComponent<Rigidbody2D>().AddForce(
                new Vector2(speedHorizontalMapper(fish.transform), 2.7f * speedVertical),
                ForceMode2D.Force
            );
            fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
        }
        else
        {
            GameObject fish = (GameObject)Instantiate(Fish[0], spawnPosition, Fish[0].GetComponent<Transform>().rotation);
            fish.GetComponent<Rigidbody2D>().AddForce(
                new Vector2(speedHorizontalMapper(fish.transform) * -1f, 2.7f * speedVertical),
                ForceMode2D.Force
            );
            fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
        }

        startFourthBool = true;
        HookManagerScript.nextFish = true;
    }

    float speedHorizontalMapper(Transform fishTransform)
    {
        return (baitSpawnPoint.position.x - fishTransform.position.x) * (baitSpawnPoint.position.x - fishTransform.position.x) * speedHorizontal * 10f;
    }

}
