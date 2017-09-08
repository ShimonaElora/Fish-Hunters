using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboScript : MonoBehaviour {

    public Text comboText;

    public static bool comboActive = false;
    public static int comboNumber = 0;

	// Use this for initialization
	void Start () {
        comboActive = false;
        comboNumber = 0;
	}
	
	// Update is called once per frame
	void Update () {
        comboText.text = comboNumber.ToString();
	}
}
