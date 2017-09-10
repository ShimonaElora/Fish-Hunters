using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameoverScript : MonoBehaviour {

    public GameObject overlay;
    public Button replay;
    public static bool gameover = false;
    GameObject[] baits = new GameObject[5];
    int check;

	// Use this for initialization
	void Start () {
        gameover = false;
        gameObject.SetActive(false);
        baits = GameObject.FindGameObjectsWithTag("bait");
        check = 0;
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < 5; i++)
        {
            if (baits[i].GetComponent<BaitScript>().initialCount <= 0)
            {
                check = check * 10 + 1;
            }
            else
            {
                check = check * 10;
            }
        }

        if (check == 11111)
        {
            gameover = true;
        } else
        {
            check = 0;
        }

	}

    void replayClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
