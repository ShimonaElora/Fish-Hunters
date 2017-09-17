using UnityEngine;
using UnityEngine.UI;

public class BaitSelectionScript : MonoBehaviour {

    public GameObject scrollRectHook;
    public GameObject scrollRectBait;
    public GameObject startButton;
    public static bool hasStarted;
    public GameObject textViews;


    // Use this for initialization
    void Start () {
        hasStarted = false;
        startButton.GetComponent<Button>().onClick.AddListener(gameStarted);
	}
	
	// Update is called once per frame
	void Update () {
        if (Camera.main.transform.position.x == 0f && !hasStarted)
        {
            scrollRectHook.SetActive(true);
            scrollRectBait.SetActive(true);
            startButton.SetActive(true);
        }
    }

    void gameStarted ()
    {
        hasStarted = true;
        gameObject.SetActive(false);
        textViews.SetActive(true);
    }
}
