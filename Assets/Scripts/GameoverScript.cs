using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameoverScript : MonoBehaviour {

    public GameObject overlay;
    public Button replay;
    public static bool gameover = false;

	// Use this for initialization
	void Start () {
        gameover = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<BaitScript>().initialCount <= 0)
        {
            gameover = true;
            overlay.SetActive(true);
            replay.onClick.AddListener(replayClicked);
        }
	}

    void replayClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
