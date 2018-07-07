using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousePointer : MonoBehaviour {


	public GameObject pointer;

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

		// 10.0fに深い意味は無い。画面に表示したいので適当な値を入れてカメラから離そうとしているだけ.
		touchScreenPosition.z       = 10.0f;

		Camera  gameCamera          = Camera.main;
		Vector3 touchWorldPosition  = gameCamera.ScreenToWorldPoint( touchScreenPosition );

		pointer.transform.position = touchWorldPosition;

		pointer.transform.Rotate(new Vector3(0, 0, 2));
	}

}
