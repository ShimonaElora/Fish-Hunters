using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawnScript : MonoBehaviour {

    public GameObject[] rocks;

	// Use this for initialization
	void Start () {
        StartCoroutine(rockSpawn());
	}

    IEnumerator rockSpawn ()
    {
        yield return new WaitForSeconds(Random.Range(5, 10));

        while (!GameoverScript.gameover)
        {
            if (BaitSelectionScript.hasStarted)
            {
                Instantiate(rocks[Random.Range(0, 7)], transform);
            }

            yield return new WaitForSeconds(Random.Range(20, 30));
        }
        
    }
}
