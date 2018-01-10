using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

	public bool head = true;

	public float Timer = 0f;
	public bool finished = false;

	public Image Train;
	public Image Car;
	public GameObject RealTrain;

	public Transform CarPos;
	public int TimerToFinish;
	public int CarStart = 0;
	public int CarFinish = 945;

	public GameObject GameEndGUI;
	public Text MoneyText;
	public Text TimeText;
	public Image Star1;
	public Image Star2;
	public Image Star3;

	public AudioSource Looesing;
	public AudioSource Winning;

	private Vector3 velocity = Vector3.zero;
	private Vector3 velocityFrom = new Vector3 (1, 1, 0);
	private float carPosInOne;
	private bool ended = false;

	void Start(){
		finished = false;
		if (!head) {
			Car.GetComponent<RectTransform> ().localPosition = new Vector3 (-360, 20, 0);
			Train.GetComponent<RectTransform> ().localPosition = new Vector3 (-360, 20, 0);
			RealTrain.transform.localScale = new Vector3 (0, 0, 1);
		}
	}

	void Update(){
		if (!ended) {
			if (!head) {
				if (finished) {
					EndTheGameScreen (Timer, carPosInOne, true);
					ended = true;
				} else {
					Timer += Time.deltaTime;

					carPosInOne = Mathf.InverseLerp (CarStart, CarFinish, CarPos.position.x);
					float finalCarPos = Mathf.Lerp (-360, 360, carPosInOne);

					Car.GetComponent<RectTransform> ().localPosition = new Vector3 (finalCarPos, 20, 0);
					Train.GetComponent<RectTransform> ().localPosition = Vector3.SmoothDamp (Train.GetComponent<RectTransform> ().localPosition, new Vector3 (360, 20, 0), ref velocity, TimerToFinish/2f);

					if (Timer > TimerToFinish - 2f) {
						RealTrain.transform.localScale = Vector3.SmoothDamp (RealTrain.transform.localScale, new Vector3 (1, 1, 1), ref velocityFrom, 2f);
					}

					if (Timer > TimerToFinish) {
						EndTheGameScreen (Timer, carPosInOne, false);
						ended = true;
					}

				}
			} else {
				carPosInOne = Mathf.InverseLerp (CarStart, CarFinish, gameObject.transform.position.x);
				if (!finished)
					Timer += Time.deltaTime;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D colInfo) {
		if (head) {
			if (colInfo.CompareTag ("Collidable") && colInfo.gameObject.name != "ENEMY") {
				if (!ended) {
					EndTheGameScreen (Timer, carPosInOne, false);
					ended = true;
				}
			}
		} else {
			if (colInfo.CompareTag ("car1") || colInfo.CompareTag ("car2") || colInfo.CompareTag ("car3")) {
				finished = true;
			}
		}
	}

	public void EndTheGameScreen(float timer, float pos, bool finished){
		Time.timeScale = 0f;
		GameEndGUI.SetActive (true);
		int moneyToWin = 0;
		if (pos < 0.5f) {
			Star1.enabled = true;
			Star2.enabled = false;
			Star3.enabled = false;
			moneyToWin = 2500;
			Looesing.Play ();
		} else if (pos > 0.5f) {
			Star1.enabled = true;
			Star2.enabled = true;
			Star3.enabled = false;
			moneyToWin = 10000;
			Looesing.Play ();
		}
		if (finished) {
			Star1.enabled = true;
			Star2.enabled = true;
			Star3.enabled = true;
			moneyToWin = 25000;
			Winning.Play ();
		}
		MoneyText.text = moneyToWin.ToString ();
		int playerMoneySaved = PlayerPrefs.GetInt ("PlayerMoney");
		playerMoneySaved += moneyToWin;
		PlayerPrefs.SetInt ("PlayerMoney", playerMoneySaved);

		int allScore = 0;
		if (PlayerPrefs.HasKey ("PlayerScore"))
			allScore = PlayerPrefs.GetInt ("PlayerScore");
		else
			PlayerPrefs.SetInt ("PlayerScore", moneyToWin);
		allScore += moneyToWin;
		PlayerPrefs.SetInt ("PlayerScore", allScore);

		float timesInt = timer * 100;
		int timesFloored = Mathf.FloorToInt (timesInt);
		float realTimer = (float)timesFloored / 100f;

		TimeText.text = realTimer.ToString ();
	}

	public void EndTheGameScreenUsingLocalInfo(bool finished){
		float pos = carPosInOne;
		float timer = Timer;

		Time.timeScale = 0f;
		GameEndGUI.SetActive (true);
		int moneyToWin = 0;
		if (pos < 0.5f) {
			Star1.enabled = true;
			Star2.enabled = false;
			Star3.enabled = false;
			moneyToWin = 2500;
		} else if (pos > 0.5f) {
			Star1.enabled = true;
			Star2.enabled = true;
			Star3.enabled = false;
			moneyToWin = 10000;
		}
		if (finished) {
			Star1.enabled = true;
			Star2.enabled = true;
			Star3.enabled = true;
			moneyToWin = 25000;
		}
		MoneyText.text = moneyToWin.ToString ();
		int playerMoneySaved = PlayerPrefs.GetInt ("PlayerMoney");
		playerMoneySaved += moneyToWin;
		PlayerPrefs.SetInt ("PlayerMoney", playerMoneySaved);

		float timesInt = timer * 100;
		int timesFloored = Mathf.FloorToInt (timesInt);
		float realTimer = (float)timesFloored / 100f;

		TimeText.text = realTimer.ToString ();
	}

	public void LoadMainMenu(){
		Time.timeScale = 1f;
		PlayerPrefs.SetInt ("CameFromGame", 1);
		SceneManager.LoadScene (0);
	}
}
