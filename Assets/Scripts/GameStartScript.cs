using UnityEngine;
using UnityEngine.UI;


public class GameStartScript : MonoBehaviour {

    public Button startButton;
    public Text startButtonText;
    public Button settingsButton;
    public Text settingsButtonText;
    public Button contactButton;
    public Text contactButtonText;
    public GameObject baitSelection;
    public GameObject overlay;

    private int startFadeHash = Animator.StringToHash("startFade");
    private int startCameraSlideHash = Animator.StringToHash("startCameraSlideAnim");

	// Use this for initialization
	void Start () {
        startButton.onClick.AddListener(buttonFadeStart);
	}
	
	// Update is called once per frame
	void Update () {

	}

    void buttonFadeStart()
    {
        GetComponent<Animator>().SetBool(startFadeHash, true);
        Camera.main.GetComponent<Animator>().SetBool(startCameraSlideHash, true);
        overlay.SetActive(true);
        baitSelection.SetActive(true);
    }
}
