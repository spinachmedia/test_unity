using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlodiaKun : MonoBehaviour {

	//他のスクリプトを参照するために使用
	public GameObject gameManager;
	public GameManager script;


	void Start () {
		gameManager = GameObject.Find( "GameObject" );
		script = gameManager.GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!GetComponent<Renderer>().isVisible) {
			Destroy(this.gameObject);
			script.deadCount++;
		}
	}
}
