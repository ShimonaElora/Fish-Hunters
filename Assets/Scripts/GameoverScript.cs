using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameoverScript : MonoBehaviour {

    public GameObject Gameover;
    public GameObject overlay;
    public Button replay;
    public static bool gameover = false;
    int check, checker;
    int baitsActive;
    HookManagerScript hookManagerScript;

	// Use this for initialization
	void Start () {
        replay.onClick.AddListener(replayClicked);
        gameover = false;
        Gameover.SetActive(false);
        hookManagerScript = GameObject.Find("Hook Hanger").GetComponent<HookManagerScript>();
        baitsActive = hookManagerScript.numberHooks;
        Debug.Log(baitsActive);
        switch (baitsActive)
        {
            case 1:
                check = 1;
                break;
            case 2:
                check = 11;
                break;
            case 3:
                check = 111;
                break;
            case 4:
                check = 1111;
                break;
            case 5:
                check = 11111;
                break;
            default:
                check = 0;
                break;
        }
        checker = 0;
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < baitsActive; i++)
        {
            if (hookManagerScript.baitInstantiated[i].GetComponent<BaitScript>().initialCount <= 0)
            {
                checker = checker * 10 + 1;
                Debug.Log(checker + " " + check);
            }
            else
            {
                checker = checker * 10;
            }
        }

        if (checker == check)
        {
            gameover = true;
        } else
        {
            checker = 0;
        }
        if (gameover)
        {
            Gameover.SetActive(true);
        }
	}

    void replayClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
