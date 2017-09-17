using UnityEngine;

public class HookHangerMotionScript : MonoBehaviour {

    private float speed;
    private int hookHangerMotionBoolHash = Animator.StringToHash("hookHangerMotionBool");

    // Use this for initialization
    void Start () {
        speed = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
        if (BaitSelectionScript.hasStarted && speed < 1)
        {
            if (transform.parent != GameObject.Find("Boat").transform) transform.SetParent(GameObject.Find("Boat").transform);
            if (!GetComponent<Animator>().GetBool(hookHangerMotionBoolHash)) GetComponent<Animator>().SetBool(hookHangerMotionBoolHash, true);
            GetComponent<Animator>().speed = speed;
            speed += 0.1f;
        }
	}
}
