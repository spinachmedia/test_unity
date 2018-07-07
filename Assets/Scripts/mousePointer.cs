using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour {


	public GameObject pointer;

	//他のスクリプトを参照するために使用
	public GameObject gameManager;
	public GameManager script;


	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find( "GameObject" );
		script = gameManager.GetComponent<GameManager>();
	}
	
	// Update is called once per frame
 	void Update() {
		if(script.flg){
		} else {
			return;
		}
		Vector3 touchScreenPosition = Input.mousePosition;
		touchScreenPosition.z       = 10.0f;
		Camera  gameCamera          = Camera.main;
		Vector3 touchWorldPosition  = gameCamera.ScreenToWorldPoint( touchScreenPosition );
		pointer.transform.position = touchWorldPosition;
		pointer.transform.Rotate(new Vector3(0, 0, 2));
	}

}
