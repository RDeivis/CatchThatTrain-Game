using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public Text MoneyText;
	public Image TurboScale;
	public Image FuelScale;
	public Image HealthScale;

	public GameObject[] car1;
	public GameObject[] car2;
	public GameObject[] car3;

	public int health = 0;
	public int armor = 0;
	public int engine = 0;
	public int fuel = 0;
	public int jetEngine = 0;
	public int jetFuel = 0;
	public int weight = 0;
	public int tires = 0;
	public int suspension = 0;
	public int weapon = 0;
	public int bullet = 0;
	private int vehicle = 1;
	void Start(){
		if (PlayerPrefs.HasKey ("PlayerSelectVehicle"))
			vehicle = PlayerPrefs.GetInt ("PlayerSelectVehicle");

		if (vehicle == 1) {

			//gameObject.GetComponent<CameraController> ().target = car1.transform;
			if (PlayerPrefs.HasKey ("PlayerVehicle1Upgrade1"))
				health = PlayerPrefs.GetInt ("PlayerVehicle1Upgrade1");
			if (PlayerPrefs.HasKey ("PlayerVehicle1Upgrade2"))
				armor = PlayerPrefs.GetInt ("PlayerVehicle1Upgrade2");
			if (PlayerPrefs.HasKey ("PlayerVehicle1Upgrade3"))
				engine = PlayerPrefs.GetInt ("PlayerVehicle1Upgrade3");
			if (PlayerPrefs.HasKey ("PlayerVehicle1Upgrade4"))
				fuel = PlayerPrefs.GetInt ("PlayerVehicle1Upgrade4");
			if (PlayerPrefs.HasKey ("PlayerVehicle1Upgrade5"))
				jetEngine = PlayerPrefs.GetInt ("PlayerVehicle1Upgrade5");
			if (PlayerPrefs.HasKey ("PlayerVehicle1Upgrade6"))
				jetFuel = PlayerPrefs.GetInt ("PlayerVehicle1Upgrade6");
			if (PlayerPrefs.HasKey ("PlayerVehicle1Upgrade7"))
				weight = PlayerPrefs.GetInt ("PlayerVehicle1Upgrade7");
			if (PlayerPrefs.HasKey ("PlayerVehicle1Upgrade8"))
				tires = PlayerPrefs.GetInt ("PlayerVehicle1Upgrade8");
			if (PlayerPrefs.HasKey ("PlayerVehicle1Upgrade9"))
				suspension = PlayerPrefs.GetInt ("PlayerVehicle1Upgrade9");
			if (PlayerPrefs.HasKey ("PlayerVehicle1Upgrade10"))
				weapon = PlayerPrefs.GetInt ("PlayerVehicle1Upgrade10");
			if (PlayerPrefs.HasKey ("PlayerVehicle1Upgrade11"))
				bullet = PlayerPrefs.GetInt ("PlayerVehicle1Upgrade11");
		} else if (vehicle == 2) {

			//gameObject.GetComponent<CameraController> ().target = car2.transform;
			if (PlayerPrefs.HasKey ("PlayerVehicle2Upgrade1"))
				health = PlayerPrefs.GetInt ("PlayerVehicle2Upgrade1");
			if (PlayerPrefs.HasKey ("PlayerVehicle2Upgrade2"))
				armor = PlayerPrefs.GetInt ("PlayerVehicle2Upgrade2");
			if (PlayerPrefs.HasKey ("PlayerVehicle2Upgrade3"))
				engine = PlayerPrefs.GetInt ("PlayerVehicle2Upgrade3");
			if (PlayerPrefs.HasKey ("PlayerVehicle2Upgrade4"))
				fuel = PlayerPrefs.GetInt ("PlayerVehicle2Upgrade4");
			if (PlayerPrefs.HasKey ("PlayerVehicle2Upgrade5"))
				jetEngine = PlayerPrefs.GetInt ("PlayerVehicle2Upgrade5");
			if (PlayerPrefs.HasKey ("PlayerVehicle2Upgrade6"))
				jetFuel = PlayerPrefs.GetInt ("PlayerVehicle2Upgrade6");
			if (PlayerPrefs.HasKey ("PlayerVehicle2Upgrade7"))
				weight = PlayerPrefs.GetInt ("PlayerVehicle2Upgrade7");
			if (PlayerPrefs.HasKey ("PlayerVehicle2Upgrade8"))
				tires = PlayerPrefs.GetInt ("PlayerVehicle2Upgrade8");
			if (PlayerPrefs.HasKey ("PlayerVehicle2Upgrade9"))
				suspension = PlayerPrefs.GetInt ("PlayerVehicle2Upgrade9");
			if (PlayerPrefs.HasKey ("PlayerVehicle2Upgrade10"))
				weapon = PlayerPrefs.GetInt ("PlayerVehicle2Upgrade10");
			if (PlayerPrefs.HasKey ("PlayerVehicle2Upgrade11"))
				bullet = PlayerPrefs.GetInt ("PlayerVehicle2Upgrade11");
		} else {

			//gameObject.GetComponent<CameraController> ().target = car3.transform;
			if (PlayerPrefs.HasKey ("PlayerVehicle3Upgrade1"))
				health = PlayerPrefs.GetInt ("PlayerVehicle3Upgrade1");
			if (PlayerPrefs.HasKey ("PlayerVehicle3Upgrade2"))
				armor = PlayerPrefs.GetInt ("PlayerVehicle3Upgrade2");
			if (PlayerPrefs.HasKey ("PlayerVehicle3Upgrade3"))
				engine = PlayerPrefs.GetInt ("PlayerVehicle3Upgrade3");
			if (PlayerPrefs.HasKey ("PlayerVehicle3Upgrade4"))
				fuel = PlayerPrefs.GetInt ("PlayerVehicle3Upgrade4");
			if (PlayerPrefs.HasKey ("PlayerVehicle3Upgrade5"))
				jetEngine = PlayerPrefs.GetInt ("PlayerVehicle3Upgrade5");
			if (PlayerPrefs.HasKey ("PlayerVehicle3Upgrade6"))
				jetFuel = PlayerPrefs.GetInt ("PlayerVehicle3Upgrade6");
			if (PlayerPrefs.HasKey ("PlayerVehicle3Upgrade7"))
				weight = PlayerPrefs.GetInt ("PlayerVehicle3Upgrade7");
			if (PlayerPrefs.HasKey ("PlayerVehicle3Upgrade8"))
				tires = PlayerPrefs.GetInt ("PlayerVehicle3Upgrade8");
			if (PlayerPrefs.HasKey ("PlayerVehicle3Upgrade9"))
				suspension = PlayerPrefs.GetInt ("PlayerVehicle3Upgrade9");
			if (PlayerPrefs.HasKey ("PlayerVehicle3Upgrade10"))
				weapon = PlayerPrefs.GetInt ("PlayerVehicle3Upgrade10");
			if (PlayerPrefs.HasKey ("PlayerVehicle3Upgrade11"))
				bullet = PlayerPrefs.GetInt ("PlayerVehicle3Upgrade11");
		}

		if (health == 0) {
			PlayerPrefs.SetInt ("PlayerHealth", 20);
		} else if (health == 1) {
			PlayerPrefs.SetInt ("PlayerHealth", 30);
		} else if (health == 2) {
			PlayerPrefs.SetInt ("PlayerHealth", 40);
		} else if (health == 3) {
			PlayerPrefs.SetInt ("PlayerHealth", 60);
		} else if (health == 4) {
			PlayerPrefs.SetInt ("PlayerHealth", 80);
		} else if (health == 5) {
			PlayerPrefs.SetInt ("PlayerHealth", 100);
		}

		if (fuel == 0) {
			PlayerPrefs.SetInt ("PlayerFuel", 20);
		} else if (fuel == 1) {
			PlayerPrefs.SetInt ("PlayerFuel", 30);
		} else if (fuel == 2) {
			PlayerPrefs.SetInt ("PlayerFuel", 40);
		} else if (fuel == 3) {
			PlayerPrefs.SetInt ("PlayerFuel", 60);
		} else if (fuel == 4) {
			PlayerPrefs.SetInt ("PlayerFuel", 80);
		} else if (fuel == 5) {
			PlayerPrefs.SetInt ("PlayerFuel", 100);
		}

		if (jetFuel == 0) {
			PlayerPrefs.SetInt ("PlayerTurbo", 0);
		} else if (jetFuel == 1) {
			PlayerPrefs.SetInt ("PlayerTurbo", 20);
		} else if (jetFuel == 2) {
			PlayerPrefs.SetInt ("PlayerTurbo", 40);
		} else if (jetFuel == 3) {
			PlayerPrefs.SetInt ("PlayerTurbo", 60);
		} else if (jetFuel == 4) {
			PlayerPrefs.SetInt ("PlayerTurbo", 80);
		} else if (jetFuel == 5) {
			PlayerPrefs.SetInt ("PlayerTurbo", 100);
		}

		PlayerPrefs.SetInt ("PlayerBulletAmount", bullet * 10);

	}

	void Update(){
		
		car1 = GameObject.FindGameObjectsWithTag ("car1");
		car2 = GameObject.FindGameObjectsWithTag ("car2");
		car3 = GameObject.FindGameObjectsWithTag ("car3");

		if (vehicle == 1) {
			for (int i = 0; i < car1.Length; i++) {
				car1 [i].SetActive (true);
			}
			for (int i = 0; i < car2.Length; i++) {
				car2 [i].SetActive (false);
			}
			for (int i = 0; i < car3.Length; i++) {
				car3 [i].SetActive (false);
			}
		} else if (vehicle == 2) {
			for (int i = 0; i < car1.Length; i++) {
				car1 [i].SetActive (false);
			}
			for (int i = 0; i < car2.Length; i++) {
				car2 [i].SetActive (true);
			}
			for (int i = 0; i < car3.Length; i++) {
				car3 [i].SetActive (false);
			}
		} else if (vehicle == 3) {
			for (int i = 0; i < car1.Length; i++) {
				car1 [i].SetActive (false);
			}
			for (int i = 0; i < car2.Length; i++) {
				car2 [i].SetActive (false);
			}
			for (int i = 0; i < car3.Length; i++) {
				car3 [i].SetActive (true);
			}
		}

		int money = 0;
		if (PlayerPrefs.HasKey ("PlayerMoney"))
			money = PlayerPrefs.GetInt ("PlayerMoney");
		else {
			PlayerPrefs.SetInt ("PlayerMoney", 500);
			money = 500;
		}
		MoneyText.text = money.ToString ();

		int turboRAW = 0;
		if (PlayerPrefs.HasKey ("PlayerTurbo"))
			turboRAW = PlayerPrefs.GetInt ("PlayerTurbo");
		float turboTemp = Mathf.InverseLerp (0, 100, turboRAW);
		float turbo = Mathf.Lerp (0, 180, turboTemp);
		TurboScale.rectTransform.sizeDelta = new Vector2 (turbo, 25);

		int fuelRAW = 0;
		if (PlayerPrefs.HasKey ("PlayerFuel"))
			fuelRAW = PlayerPrefs.GetInt ("PlayerFuel");
		float fuelTemp = Mathf.InverseLerp (0, 100, fuelRAW);
		float fuel = Mathf.Lerp (0, 180, fuelTemp);
		FuelScale.rectTransform.sizeDelta = new Vector2 (fuel, 25);

		int helthRAW = 0;
		if (PlayerPrefs.HasKey ("PlayerHealth"))
			helthRAW = PlayerPrefs.GetInt ("PlayerHealth");
		float healthTemp = Mathf.InverseLerp (0, 100, helthRAW);
		float health = Mathf.Lerp (0, 180, healthTemp);
		HealthScale.rectTransform.sizeDelta = new Vector2 (health, 25);
	}
}
