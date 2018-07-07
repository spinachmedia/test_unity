using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glodia_kun : MonoBehaviour {

	// public GameObject glodia_kun;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!GetComponent<Renderer>().isVisible) {
			Destroy(this.gameObject);
		}
	}
}
