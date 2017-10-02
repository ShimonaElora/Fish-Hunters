using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class FishSpawnScript : MonoBehaviour {

    public Transform[] spawnPoints;
    public GameObject shadow;
    public Text text;

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

    HookManagerScript hookManagerScript;

	// Use this for initialization
	void Start () {
        hookManagerScript = GameObject.Find("Hook Hanger").GetComponent<HookManagerScript>();
        StartCoroutine(startWait());
	}
	
	// Update is called once per frame
	void Update () {

        //speedVertical = 500 * (3 + gravityScale) / 6f;

        if (!GameoverScript.gameover && BaitSelectionScript.hasStarted)
        {
            if (startFirstBool)
            {
                startFirstBool = false;
                StartCoroutine(foreGroundFish());
            }
            if (startSecondBool)
            {
                startSecondBool = false;
                StartCoroutine(midGroundFish());
            }
            if (startThirdBool)
            {
                startThirdBool = false;
                StartCoroutine(backGroundFish());
            }
            if (startFourthBool)
            {
                startFourthBool = false;
                StartCoroutine(extraFish());
            }
        }
    }

    IEnumerator startWait()
    {
        yield return new WaitForSeconds(1);
        startFirstBool = true;

        yield return new WaitForSeconds(15);
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

        int index = Random.Range(0, hookManagerScript.numberHooks);
        if (hookManagerScript.baitInstantiated[index].GetComponent<BaitScript>().initialCount > 0)
        {
            Fish = new GameObject[2] { hookManagerScript.fishes[(hookManagerScript.baitOrder[index] - 1) * 2], hookManagerScript.fishes[(hookManagerScript.baitOrder[index] - 1) * 2 + 1] };
            spawnPoints = new Transform[2] {
                hookManagerScript.hooks[index].transform.Find("Fish Spawn Points").transform.Find("start").GetComponent<Transform>(),
                hookManagerScript.hooks[index].transform.Find("Fish Spawn Points").transform.Find("end").GetComponent<Transform>()
            };
            baitSpawnPoint = hookManagerScript.hooks[index].transform.Find("baitSpawnPoint").GetComponent<Transform>();

            Vector3 spawnPosition = new Vector3(Random.Range(spawnPoints[0].position.x, spawnPoints[1].position.x), spawnPoints[0].position.y, spawnPoints[0].position.z);

            Instantiate(shadow, spawnPosition, shadow.GetComponent<Transform>().rotation);

            yield return new WaitForSeconds(1);

            if (spawnPosition.x <= baitSpawnPoint.position.x)
            {
                GameObject fish = (GameObject)Instantiate(Fish[1], spawnPosition, Fish[1].GetComponent<Transform>().rotation);
                if (fish.gameObject.name == "Fish1L(Clone)" || fish.gameObject.name == "Fish1R(Clone)" || fish.gameObject.name == "Fish2L(Clone)" || fish.gameObject.name == "Fish2R(Clone)")
                {
                    fish.GetComponent<Rigidbody2D>().AddForce(
                        new Vector2(speedHorizontalMapper(fish.transform), 2.7f * speedVertical * 1.22f),
                        ForceMode2D.Force
                    );
                    fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale * 1.3f * 1.3f;
                }
                else if (fish.gameObject.name == "Fish3L(Clone)" || fish.gameObject.name == "Fish3R(Clone)")
                {
                    fish.GetComponent<Rigidbody2D>().AddForce(
                        new Vector2(speedHorizontalMapper(fish.transform), 2.7f * speedVertical * 1.15f),
                        ForceMode2D.Force
                    );
                    fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale * 1.2f * 1.2f;
                }
                else
                {
                    fish.GetComponent<Rigidbody2D>().AddForce(
                        new Vector2(speedHorizontalMapper(fish.transform), 2.7f * speedVertical),
                        ForceMode2D.Force
                    );
                    fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
                }
                fish.GetComponent<FishScript>().text = text;
            }
            else
            {
                GameObject fish = (GameObject)Instantiate(Fish[0], spawnPosition, Fish[0].GetComponent<Transform>().rotation);
                if (fish.gameObject.name == "Fish1L(Clone)" || fish.gameObject.name == "Fish1R(Clone)" || fish.gameObject.name == "Fish2L(Clone)" || fish.gameObject.name == "Fish2R(Clone)")
                {
                    fish.GetComponent<Rigidbody2D>().AddForce(
                        new Vector2(speedHorizontalMapper(fish.transform) * -1f, 2.7f * speedVertical * 1.22f),
                        ForceMode2D.Force
                    );
                    fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale * 1.3f * 1.3f;
                }
                else if (fish.gameObject.name == "Fish3L(Clone)" || fish.gameObject.name == "Fish3R(Clone)")
                {
                    fish.GetComponent<Rigidbody2D>().AddForce(
                        new Vector2(speedHorizontalMapper(fish.transform) * -1f, 2.7f * speedVertical * 1.15f),
                        ForceMode2D.Force
                    );
                    fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale * 1.2f * 1.2f;
                }
                else
                {
                    fish.GetComponent<Rigidbody2D>().AddForce(
                        new Vector2(speedHorizontalMapper(fish.transform) * -1f, 2.7f * speedVertical),
                        ForceMode2D.Force
                    );
                    fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
                }
                fish.GetComponent<FishScript>().text = text;
            }
        }

        startFirstBool = true;
    }

    IEnumerator midGroundFish()
    {
        time = Random.Range(3, 6);
        yield return new WaitForSeconds(time);

        int index = Random.Range(0, hookManagerScript.numberHooks);
        if (hookManagerScript.baitInstantiated[index].GetComponent<BaitScript>().initialCount > 0)
        {
            Fish = new GameObject[2] { hookManagerScript.fishes[(hookManagerScript.baitOrder[index] - 1) * 2], hookManagerScript.fishes[(hookManagerScript.baitOrder[index] - 1) * 2 + 1] };
            spawnPoints = new Transform[2] {
            hookManagerScript.hooks[index].transform.Find("Fish Spawn Points").transform.Find("start").GetComponent<Transform>(),
            hookManagerScript.hooks[index].transform.Find("Fish Spawn Points").transform.Find("end").GetComponent<Transform>()
        };
            baitSpawnPoint = hookManagerScript.hooks[index].transform.Find("baitSpawnPoint").GetComponent<Transform>();

            Vector3 spawnPosition = new Vector3(Random.Range(spawnPoints[0].position.x, spawnPoints[1].position.x), spawnPoints[0].position.y, spawnPoints[0].position.z);

            Instantiate(shadow, spawnPosition, shadow.GetComponent<Transform>().rotation);

            yield return new WaitForSeconds(1);

            if (spawnPosition.x <= baitSpawnPoint.position.x)
            {
                GameObject fish = (GameObject)Instantiate(Fish[1], spawnPosition, Fish[1].GetComponent<Transform>().rotation);
                if (fish.gameObject.name == "Fish1L(Clone)" || fish.gameObject.name == "Fish1R(Clone)" || fish.gameObject.name == "Fish2L(Clone)" || fish.gameObject.name == "Fish2R(Clone)")
                {
                    fish.GetComponent<Rigidbody2D>().AddForce(
                        new Vector2(speedHorizontalMapper(fish.transform), 2.7f * speedVertical * 1.22f),
                        ForceMode2D.Force
                    );
                    fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale * 1.3f * 1.3f;
                }
                else if (fish.gameObject.name == "Fish3L(Clone)" || fish.gameObject.name == "Fish3R(Clone)")
                {
                    fish.GetComponent<Rigidbody2D>().AddForce(
                        new Vector2(speedHorizontalMapper(fish.transform), 2.7f * speedVertical * 1.15f),
                        ForceMode2D.Force
                    );
                    fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale * 1.2f * 1.2f;
                }
                else
                {
                    fish.GetComponent<Rigidbody2D>().AddForce(
                        new Vector2(speedHorizontalMapper(fish.transform), 2.7f * speedVertical),
                        ForceMode2D.Force
                    );
                    fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
                }
                fish.GetComponent<FishScript>().text = text;
            }
            else
            {
                GameObject fish = (GameObject)Instantiate(Fish[0], spawnPosition, Fish[0].GetComponent<Transform>().rotation);
                if (fish.gameObject.name == "Fish1L(Clone)" || fish.gameObject.name == "Fish1R(Clone)" || fish.gameObject.name == "Fish2L(Clone)" || fish.gameObject.name == "Fish2R(Clone)")
                {
                    fish.GetComponent<Rigidbody2D>().AddForce(
                        new Vector2(speedHorizontalMapper(fish.transform) * -1f, 2.7f * speedVertical * 1.22f),
                        ForceMode2D.Force
                    );
                    fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale * 1.3f * 1.3f;
                }
                else if (fish.gameObject.name == "Fish3L(Clone)" || fish.gameObject.name == "Fish3R(Clone)")
                {
                    fish.GetComponent<Rigidbody2D>().AddForce(
                        new Vector2(speedHorizontalMapper(fish.transform) * -1f, 2.7f * speedVertical * 1.15f),
                        ForceMode2D.Force
                    );
                    fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale * 1.2f * 1.2f;
                }
                else
                {
                    fish.GetComponent<Rigidbody2D>().AddForce(
                        new Vector2(speedHorizontalMapper(fish.transform) * -1f, 2.7f * speedVertical),
                        ForceMode2D.Force
                    );
                    fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
                }
                fish.GetComponent<FishScript>().text = text;
            }
        }

        startSecondBool = true;
    }

    IEnumerator backGroundFish()
    {
        time = Random.Range(4, 7);
        yield return new WaitForSeconds(time);

        int index = Random.Range(0, hookManagerScript.numberHooks);
        if (hookManagerScript.baitInstantiated[index].GetComponent<BaitScript>().initialCount > 0)
        {
            Fish = new GameObject[2] { hookManagerScript.fishes[(hookManagerScript.baitOrder[index] - 1) * 2], hookManagerScript.fishes[(hookManagerScript.baitOrder[index] - 1) * 2 + 1] };
            spawnPoints = new Transform[2] {
                hookManagerScript.hooks[index].transform.Find("Fish Spawn Points").transform.Find("start").GetComponent<Transform>(),
                hookManagerScript.hooks[index].transform.Find("Fish Spawn Points").transform.Find("end").GetComponent<Transform>()
            };
            baitSpawnPoint = hookManagerScript.hooks[index].transform.Find("baitSpawnPoint").GetComponent<Transform>();

            Vector3 spawnPosition = new Vector3(Random.Range(spawnPoints[0].position.x, spawnPoints[1].position.x), spawnPoints[0].position.y, spawnPoints[0].position.z);

            Instantiate(shadow, spawnPosition, shadow.GetComponent<Transform>().rotation);

            yield return new WaitForSeconds(1);

            if (spawnPosition.x <= baitSpawnPoint.position.x)
            {
                GameObject fish = (GameObject)Instantiate(Fish[1], spawnPosition, Fish[1].GetComponent<Transform>().rotation);
                if (fish.gameObject.name == "Fish1L(Clone)" || fish.gameObject.name == "Fish1R(Clone)" || fish.gameObject.name == "Fish2L(Clone)" || fish.gameObject.name == "Fish2R(Clone)")
                {
                    fish.GetComponent<Rigidbody2D>().AddForce(
                        new Vector2(speedHorizontalMapper(fish.transform), 2.7f * speedVertical * 1.22f),
                        ForceMode2D.Force
                    );
                    fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale * 1.3f * 1.3f;
                }
                else if (fish.gameObject.name == "Fish3L(Clone)" || fish.gameObject.name == "Fish3R(Clone)")
                {
                    fish.GetComponent<Rigidbody2D>().AddForce(
                        new Vector2(speedHorizontalMapper(fish.transform), 2.7f * speedVertical * 1.15f),
                        ForceMode2D.Force
                    );
                    fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale * 1.2f * 1.2f;
                }
                else
                {
                    fish.GetComponent<Rigidbody2D>().AddForce(
                        new Vector2(speedHorizontalMapper(fish.transform), 2.7f * speedVertical),
                        ForceMode2D.Force
                    );
                    fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
                }
                fish.GetComponent<FishScript>().text = text;
            }
            else
            {
                GameObject fish = (GameObject)Instantiate(Fish[0], spawnPosition, Fish[0].GetComponent<Transform>().rotation);
                if (fish.gameObject.name == "Fish1L(Clone)" || fish.gameObject.name == "Fish1R(Clone)" || fish.gameObject.name == "Fish2L(Clone)" || fish.gameObject.name == "Fish2R(Clone)")
                {
                    fish.GetComponent<Rigidbody2D>().AddForce(
                        new Vector2(speedHorizontalMapper(fish.transform) * -1f, 2.7f * speedVertical * 1.22f),
                        ForceMode2D.Force
                    );
                    fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale * 1.3f * 1.3f;
                }
                else if (fish.gameObject.name == "Fish3L(Clone)" || fish.gameObject.name == "Fish3R(Clone)")
                {
                    fish.GetComponent<Rigidbody2D>().AddForce(
                        new Vector2(speedHorizontalMapper(fish.transform) * -1f, 2.7f * speedVertical * 1.15f),
                        ForceMode2D.Force
                    );
                    fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale * 1.2f * 1.2f;
                }
                else
                {
                    fish.GetComponent<Rigidbody2D>().AddForce(
                        new Vector2(speedHorizontalMapper(fish.transform) * -1f, 2.7f * speedVertical),
                        ForceMode2D.Force
                    );
                    fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
                }
                fish.GetComponent<FishScript>().text = text;
            }
        }
        startThirdBool = true;
    }

    IEnumerator extraFish()
    {
        time = Random.Range(5, 10);
        yield return new WaitForSeconds(time);

        int index = Random.Range(0, hookManagerScript.numberHooks);
        if (hookManagerScript.baitInstantiated[index].GetComponent<BaitScript>().initialCount > 0)
        {
            Fish = new GameObject[2] { hookManagerScript.fishes[(hookManagerScript.baitOrder[index] - 1) * 2], hookManagerScript.fishes[(hookManagerScript.baitOrder[index] - 1) * 2 + 1] };
            spawnPoints = new Transform[2] {
                hookManagerScript.hooks[index].transform.Find("Fish Spawn Points").transform.Find("start").GetComponent<Transform>(),
                hookManagerScript.hooks[index].transform.Find("Fish Spawn Points").transform.Find("end").GetComponent<Transform>()
            };
            baitSpawnPoint = hookManagerScript.hooks[index].transform.Find("baitSpawnPoint").GetComponent<Transform>();

            Vector3 spawnPosition = new Vector3(Random.Range(spawnPoints[0].position.x, spawnPoints[1].position.x), spawnPoints[0].position.y, spawnPoints[0].position.z);

            Instantiate(shadow, spawnPosition, shadow.GetComponent<Transform>().rotation);

            yield return new WaitForSeconds(1);

            if (spawnPosition.x <= baitSpawnPoint.position.x)
            {
                GameObject fish = (GameObject)Instantiate(Fish[1], spawnPosition, Fish[1].GetComponent<Transform>().rotation);
                if (fish.gameObject.name == "Fish1L(Clone)" || fish.gameObject.name == "Fish1R(Clone)" || fish.gameObject.name == "Fish2L(Clone)" || fish.gameObject.name == "Fish2R(Clone)")
                {
                    fish.GetComponent<Rigidbody2D>().AddForce(
                        new Vector2(speedHorizontalMapper(fish.transform) * -1f, 2.7f * speedVertical * 1.22f),
                        ForceMode2D.Force
                    );
                    fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale * 1.3f * 1.3f;
                }
                else if (fish.gameObject.name == "Fish3L(Clone)" || fish.gameObject.name == "Fish3R(Clone)")
                {
                    fish.GetComponent<Rigidbody2D>().AddForce(
                        new Vector2(speedHorizontalMapper(fish.transform) * -1f, 2.7f * speedVertical * 1.15f),
                        ForceMode2D.Force
                    );
                    fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale * 1.2f * 1.2f;
                }
                else
                {
                    fish.GetComponent<Rigidbody2D>().AddForce(
                        new Vector2(speedHorizontalMapper(fish.transform), 2.7f * speedVertical),
                        ForceMode2D.Force
                    );
                    fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
                }
                fish.GetComponent<FishScript>().text = text;
            }
            else
            {
                GameObject fish = (GameObject)Instantiate(Fish[0], spawnPosition, Fish[0].GetComponent<Transform>().rotation);
                if (fish.gameObject.name == "Fish1L(Clone)" || fish.gameObject.name == "Fish1R(Clone)" || fish.gameObject.name == "Fish2L(Clone)" || fish.gameObject.name == "Fish2R(Clone)")
                {
                    fish.GetComponent<Rigidbody2D>().AddForce(
                        new Vector2(speedHorizontalMapper(fish.transform) * -1f, 2.7f * speedVertical * 1.22f),
                        ForceMode2D.Force
                    );
                    fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale * 1.3f * 1.3f;
                }
                else if (fish.gameObject.name == "Fish3L(Clone)" || fish.gameObject.name == "Fish3R(Clone)")
                {
                    fish.GetComponent<Rigidbody2D>().AddForce(
                        new Vector2(speedHorizontalMapper(fish.transform) * -1f, 2.7f * speedVertical * 1.15f),
                        ForceMode2D.Force
                    );
                    fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale * 1.2f * 1.2f;
                }
                else
                {
                    fish.GetComponent<Rigidbody2D>().AddForce(
                        new Vector2(speedHorizontalMapper(fish.transform) * -1f, 2.7f * speedVertical),
                        ForceMode2D.Force
                    );
                    fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
                }
                fish.GetComponent<FishScript>().text = text;
            }
        }
        startFourthBool = true;
    }

    float speedHorizontalMapper(Transform fishTransform)
    {
        return (baitSpawnPoint.position.x - fishTransform.position.x) * (baitSpawnPoint.position.x - fishTransform.position.x) * speedHorizontal * 10f;
    }

}
