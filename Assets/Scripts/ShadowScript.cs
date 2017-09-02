using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(DestroyWait());
	}
	
    IEnumerator DestroyWait ()
    {
        yield return new WaitForSeconds(1.1f);
        Destroy(gameObject);
    }

}
