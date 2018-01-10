using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsController : MonoBehaviour {

	public bool money = false;

	public int MoneyAmount = 0;

	public AudioSource CollectSound;
	public GameObject CoinCollect;

	void OnTriggerEnter2D(Collider2D col){
		if (money) {
			CollectSound.Play ();
			AddMoney (MoneyAmount);
			Destroy (gameObject);
			GameObject temp = Instantiate (CoinCollect, gameObject.transform.position, gameObject.transform.rotation);
			temp.GetComponent<ParticleSystem> ().Play ();
		}
	}

	void AddMoney(int money){
		int allMoney = money;
		int allScore = 0;

		if (PlayerPrefs.HasKey ("PlayerMoney"))
			allMoney = money + PlayerPrefs.GetInt ("PlayerMoney");

		if (PlayerPrefs.HasKey ("PlayerScore"))
			allScore = PlayerPrefs.GetInt ("PlayerScore");
		else
			PlayerPrefs.SetInt ("PlayerScore", money);

		allScore += money;

		PlayerPrefs.SetInt ("PlayerMoney", allMoney);
		PlayerPrefs.SetInt ("PlayerScore", allScore);
	}
}
