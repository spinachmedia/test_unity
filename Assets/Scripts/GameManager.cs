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

	public int deadCount = 0;


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

		//Glodiaくんの数を取得
		glodia_kuns = GameObject.FindGameObjectsWithTag("GlodiaKun");
        int sco = glodia_kuns.Length;
		score.text = sco.ToString();

		// マウスでクリックした場所にグローディアくんが出現する
		if (Input.GetMouseButtonDown(0)) {
			Debug.Log("Click");
			clickPosition = Input.mousePosition;
			clickPosition.z = 10f;
			float rotate = pointer.transform.localEulerAngles.z;
			Vector3 axis = new Vector3(0f, 0f, 1f);
			Quaternion rote = Quaternion.AngleAxis(rotate, axis);
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
		resultCountNg.text = deadCount.ToString();
	}
}
