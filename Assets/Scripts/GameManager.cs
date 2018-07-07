using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public bool flg = false;
	public GameObject glodia_kun;
	private Vector3 clickPosition;

	public GameObject pointer;

	GameObject[] glodia_kuns;

	
	public Text countDown;
	public Text time;
	public Text score;
	public Text message;



	
	public GameObject resultBoard;
	public Text resultCountOk;
	public Text resultCountNg;

	int i = 0;

	public bool getFlg(){
		return flg;
	}


	// Use this for initialization
	void Start () {
		resultBoard.gameObject.SetActive(false);
		Debug.Log("Start");
		StartCoroutine(CountdownCoroutine());

	}
	
	// Update is called once per frame
	void Update () {

		//開始まではreturn
		if(flg){
			
		} else {
			return;
		}


		glodia_kuns = GameObject.FindGameObjectsWithTag("GlodiaKun");
        int sco = glodia_kuns.Length;
		score.text = sco.ToString();

		// マウスでクリックした場所にグローディアくんが出現する
		if (Input.GetMouseButtonDown(0)) {
			Debug.Log("Click");
			clickPosition = Input.mousePosition;
			clickPosition.z = 10f;

			float rotate = pointer.transform.localEulerAngles.z;

			// 位置

			// 角度
			Vector3 axis = new Vector3(0f, 0f, 1f); // 回転軸 Z軸だよ
			Quaternion rote = Quaternion.AngleAxis(rotate, axis);

            //Instantiate( 生成するオブジェクト,  場所, 回転 );
            GameObject obj = Instantiate (glodia_kun, Camera.main.ScreenToWorldPoint(clickPosition), rote);
			obj.tag = "GlodiaKun";
        }

	}

	IEnumerator CountdownCoroutine()
	{
		// _imageMask.gameObject.SetActive(true);
		countDown.gameObject.SetActive(true);
 
		countDown.text = "3";
		yield return new WaitForSeconds(1.0f);
 
		countDown.text = "2";
		yield return new WaitForSeconds(1.0f);
 
		countDown.text = "1";
		yield return new WaitForSeconds(1.0f);
		
		countDown.text = "GO!";
		yield return new WaitForSeconds(1.0f);
 
		countDown.text = "";
		countDown.gameObject.SetActive(false);

		message.text = "";
		message.gameObject.SetActive(false);

		flg = true;

		
		StartCoroutine(CountdownGame());

		// _imageMask.gameObject.SetActive(false);
	}


	int timeMax = 10;
	IEnumerator CountdownGame()
	{ 

		time.text = "5";
		yield return new WaitForSeconds(1.0f);
 
		time.text = "4";
		yield return new WaitForSeconds(1.0f);
 
		time.text = "3";
		yield return new WaitForSeconds(1.0f);
		
		time.text = "2";
		yield return new WaitForSeconds(1.0f);

		time.text = "1";
		yield return new WaitForSeconds(1.0f);

		time.text = "0";
		yield return new WaitForSeconds(1.0f);
 
		time.text = "";
		flg = false;

		yield return new WaitForSeconds(3.0f);
		finish();
		

		
	}


	void finish (){
		resultBoard.gameObject.SetActive(true);
		resultCountOk.text = score.text;
	}
}
