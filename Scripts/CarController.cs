using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using UnityStandardAssets.CrossPlatformInput;

public class CarController : MonoBehaviour {

	public float speed = 1500f;
	public float rotationSpeed = 15f;
	public WheelJoint2D backWheel;
	public WheelJoint2D frontWheel;
	public Rigidbody2D rb;
	public GameObject FinishLine;
	public GameObject LowFuel;
	public GameObject LowJetFuel;
	public GameObject LowHealth;
	public GameObject cameraPlayer;
	public PhysicsMaterial2D Tires;
	public Text BulletCount;
	public Transform FireingPosition;
	public AudioSource JetEngineSound;
	public AudioSource Warning;
	public bool PlayedWorningOnce = false;

	private float movement = 0f;
	private float rotation = 0f;
	private float timer = 1f;
	private float timerJet = 1f;
	private float timerArmor = 0f;
	private float engineTimer = 0f;
	private float jetEngineTimer = 0f;
	private float armorTimer = 0f;

	private int armor;//done
	private int engine;//done
	private int jetEngine;//done
	private int weight;//done
	private int tires;//done
	private int suspension;//done
	public int weapon;
	public int bullets;

	private float threshold = 2f;
	private float threshVelocity = 0f;

	void Start(){
		GameObject Info = GameObject.FindGameObjectWithTag ("Info");
		FinishLine = Info.GetComponent<GiveInfo> ().FinishLine;
		LowFuel = Info.GetComponent<GiveInfo> ().LowFuel;
		LowJetFuel = Info.GetComponent<GiveInfo> ().LowJetFuel;
		LowHealth = Info.GetComponent<GiveInfo> ().LowHealth;
		cameraPlayer = Info.GetComponent<GiveInfo> ().CameraPlayer;
		BulletCount = Info.GetComponent<GiveInfo> ().BulletCount;
		JetEngineSound = Info.GetComponent<GiveInfo> ().JetEngineSound;
		Warning = Info.GetComponent<GiveInfo> ().WarningSound;
	}

	void Update(){
		/*
		if (PhotonNetwork.isMasterClient == false) {
			return;
		} else {
			cameraPlayer.GetComponent<CameraController> ().target = gameObject.transform;
		}*/
		cameraPlayer.GetComponent<CameraController> ().target = gameObject.transform;
		/***************************
		 * FIREING RANGE *
		 * ***************************/

		if (jetEngine == 0) {
			jetEngineTimer = 0.25f;
		} else if (jetEngine == 1) {
			jetEngineTimer = 0.5f;
		} else if (jetEngine == 2) {
			jetEngineTimer = 0.75f;
		} else if (jetEngine == 3) {
			jetEngineTimer = 1f;
		} else if (jetEngine == 4) {
			jetEngineTimer = 1.25f;
		} else if (jetEngine == 5) {
			jetEngineTimer = 1.5f;
		}

		int jetFuel = 0;
		if (PlayerPrefs.HasKey ("PlayerTurbo"))
			jetFuel = PlayerPrefs.GetInt ("PlayerTurbo");


		if (Input.GetKey (KeyCode.LeftShift)) {
			if (jetEngine > 0) {
				if (jetFuel > 0) {
					if (timerJet > 0)
						timerJet -= Time.fixedDeltaTime;
					else {
						timerJet = jetEngineTimer;
						jetFuel--;
						PlayerPrefs.SetInt ("PlayerTurbo", jetFuel);
					}
					if (jetFuel < 10)
						LowJetFuel.SetActive (true);
					else
						LowJetFuel.SetActive (false);
					gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 1000 * Time.deltaTime);
					JetEngineSound.Play ();
				}
			}
		} else {
			JetEngineSound.Pause ();
		}

		/***************************
		* FIREING RANGE END*
		* ***************************/


		movement = -CrossPlatformInputManager.GetAxis ("Vertical") * speed;
		rotation = -CrossPlatformInputManager.GetAxis ("Horizontal");

		weight = cameraPlayer.GetComponent<Player> ().weight;
		suspension = cameraPlayer.GetComponent<Player> ().suspension;
		engine = cameraPlayer.GetComponent<Player> ().engine;
		jetEngine = cameraPlayer.GetComponent<Player> ().jetEngine;
		tires = cameraPlayer.GetComponent<Player> ().tires;
		armor = cameraPlayer.GetComponent<Player> ().armor;
		weapon = cameraPlayer.GetComponent<Player> ().weapon;
		bullets = cameraPlayer.GetComponent<Player> ().bullet * 10;

		if (weight == 0)
			gameObject.GetComponent<Rigidbody2D> ().mass = 10;
		else if(weight == 1)
			gameObject.GetComponent<Rigidbody2D> ().mass = 9;
		else if(weight == 2)
			gameObject.GetComponent<Rigidbody2D> ().mass = 8;
		else if(weight == 3)
			gameObject.GetComponent<Rigidbody2D> ().mass = 7;
		else if(weight == 4)
			gameObject.GetComponent<Rigidbody2D> ().mass = 6;
		else if(weight == 5)
			gameObject.GetComponent<Rigidbody2D> ().mass = 5;

		JointSuspension2D susp = new JointSuspension2D();
		susp.dampingRatio = 0.7f;
		susp.angle = 90;
		susp.frequency = 4;

		if (suspension == 0) {
			susp.frequency = 4;
		} else if (suspension == 1) {
			susp.frequency = 5;
		} else if (suspension == 2) {
			susp.frequency = 6;
		} else if (suspension == 3) {
			susp.frequency = 7;
		} else if (suspension == 4) {
			susp.frequency = 8;
		} else if (suspension == 5) {
			susp.frequency = 10;
		}
		backWheel.suspension = susp;
		frontWheel.suspension = susp;

		if (engine == 0) {
			engineTimer = 0.25f;
		} else if (engine == 1) {
			engineTimer = 0.5f;
		} else if (engine == 2) {
			engineTimer = 0.75f;
		} else if (engine == 3) {
			engineTimer = 1f;
		} else if (engine == 4) {
			engineTimer = 1.25f;
		} else if (engine == 5) {
			engineTimer = 1.5f;
		}

		if (tires == 0) {
			Tires.friction = 0.25f;
		} else if (tires == 1) {
			Tires.friction = 0.5f;
		} else if (tires == 2) {
			Tires.friction = 0.75f;
		} else if (tires == 3) {
			Tires.friction = 1f;
		} else if (tires == 4) {
			Tires.friction = 1.5f;
		} else if (tires == 5) {
			Tires.friction = 2.5f;
		}

		if (armor == 0) {
			armorTimer = 0.1f;
		} else if (armor == 1) {
			armorTimer = 0.25f;
		} else if (armor == 2) {
			armorTimer = 0.5f;
		} else if (armor == 3) {
			armorTimer = 0.75f;
		} else if (armor == 4) {
			armorTimer = 1f;
		} else if (armor == 5) {
			armorTimer = 1.5f;
		}

		if (timerArmor > 0)
			timerArmor -= Time.deltaTime;

		int bulletAmount = 0;
		if (PlayerPrefs.HasKey ("PlayerBulletAmount")) {
			bulletAmount = PlayerPrefs.GetInt ("PlayerBulletAmount");
		} else {
			PlayerPrefs.SetInt ("PlayerBulletAmount", bullets);
			bulletAmount = bullets;
		}

		BulletCount.text = "x" + bulletAmount.ToString ();
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.CompareTag ("Collidable")) {
			if (timerArmor <= 0) {
				int healthNow = PlayerPrefs.GetInt ("PlayerHealth");
				healthNow--;
				PlayerPrefs.SetInt ("PlayerHealth", healthNow);
				timerArmor = armorTimer;
				if (col.gameObject.name == "ENEMY") {
					healthNow = PlayerPrefs.GetInt ("PlayerHealth");
					healthNow-=9;
					Debug.Log ("MinuMoreHealth");
					PlayerPrefs.SetInt ("PlayerHealth", healthNow);
				}
			}
		}
	}

	void FixedUpdate(){

		if (threshold < 1.5) {
			threshold = Mathf.SmoothDamp (threshold, 1.5f, ref threshVelocity, 1f);
			cameraPlayer.GetComponent<BloomOptimized> ().threshold = threshold;
		}


		if (movement == 0f) {
			backWheel.useMotor = false;
			frontWheel.useMotor = false;
		} else {

			int fuel = 0;
			if (PlayerPrefs.HasKey ("PlayerFuel"))
				fuel = PlayerPrefs.GetInt ("PlayerFuel");

			int health = 0;
			if (PlayerPrefs.HasKey ("PlayerHealth"))
				health = PlayerPrefs.GetInt ("PlayerHealth");

			if (fuel > 0) {
				if (timer > 0)
					timer -= Time.fixedDeltaTime;
				else {
					timer = engineTimer;
					fuel--;
					PlayerPrefs.SetInt ("PlayerFuel", fuel);
				}
				backWheel.useMotor = true;
				frontWheel.useMotor = true;
				if (fuel < 10) {
					LowFuel.SetActive (true);
					if (!PlayedWorningOnce) {
						Warning.Play ();
						PlayedWorningOnce = true;
						threshold = 0f;
					}
				}
				else
					LowFuel.SetActive (false);
			} else {
				FinishLine.GetComponent<EndGame> ().EndTheGameScreenUsingLocalInfo (false);
				backWheel.useMotor = false;
				frontWheel.useMotor = false;
			}

			if (health > 10) {
				LowHealth.SetActive (false);
			} else if (health > 0) {
				LowHealth.SetActive (true);
			} else {
				FinishLine.GetComponent<EndGame> ().EndTheGameScreenUsingLocalInfo (false);
			}

			JointMotor2D motor = new JointMotor2D { motorSpeed = movement, maxMotorTorque = backWheel.motor.maxMotorTorque };
			backWheel.motor = motor;
			frontWheel.motor = motor;
		}

		rb.AddTorque (-rotation * rotationSpeed * Time.fixedDeltaTime);

	}

}
