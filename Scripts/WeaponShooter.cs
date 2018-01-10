using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooter : MonoBehaviour {

	private int bullets;
	private int weapons;
	public GameObject CarObject;
	public GameObject bullet;
	public AudioSource ShootingBullet;

	private Transform bulPos;
	private bool startShooting = false;
	private float timer = 0.25f;
	private Transform pos;

	void OnTriggerEnter2D(Collider2D col){
		pos = col.gameObject.transform;
		startShooting = true;
	}

	void OnTriggerExit2D(Collider2D col){
		startShooting = false;
	}

	void Start(){
		ShootingBullet = GameObject.Find ("ShootSound").GetComponent<AudioSource> ();
	}

	void Update(){
		if (!pos)
			startShooting = false;
		
		if (startShooting && timer <= 0) {
			bullets = PlayerPrefs.GetInt ("PlayerBulletAmount");
			weapons = CarObject.GetComponent<CarController> ().weapon;
			Debug.Log ("READY TO SHOOT-" + bullets + "_" + weapons);
			if (bullets > 0 && weapons > 0) {

				Debug.Log ("SHOOTING");

				GameObject bulletTemp = Instantiate (bullet, gameObject.transform.position, Quaternion.Euler (Vector3.zero));
				ShootingBullet.Play ();
				bulletTemp.GetComponent<BulletFly> ().SetTarget (pos.position);
				if (weapons == 1) {
					bulletTemp.name = "Bullet1";
				} else if (weapons == 2) {
					bulletTemp.name = "Bullet2";
				} else if (weapons == 3) {
					bulletTemp.name = "Bullet3";
				} else if (weapons == 4) {
					bulletTemp.name = "Bullet4";
				} else if (weapons == 5) {
					bulletTemp.name = "Bullet5";
				}
				bullets--;
				PlayerPrefs.SetInt ("PlayerBulletAmount", bullets);
				Debug.Log (bullets);
				timer = 0.25f;
			}
		} else {
			timer -= Time.deltaTime;
		}
	}
}
