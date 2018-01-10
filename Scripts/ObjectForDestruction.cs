using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectForDestruction : MonoBehaviour {

	public int health = 150;
	public float timer = 0.1f;
	public bool crate = true;
	public AudioSource CrateBreak;
	public AudioSource Death;
	private float deathTimer = 0.15f;
	public ParticleSystem ps;

	public AnimationClip Idle;
	public AnimationClip Walk;
	public AnimationClip Dead;
	public AnimationClip Attack;

	private Transform enemyTransform;
	private bool enemySpotted = false;
	private bool attack = false;

	private float timerToStartWalking = 1f;
	private float timerToDieAfterAttack = 0f;
	private float timerToDestroy = 0f;

	void Start(){
		if(!crate)
			gameObject.GetComponent<Animator> ().Play ("IdleState");
	}

	void OnTriggerEnter2D(Collider2D col){
		if (!crate) {
			if (col.gameObject.CompareTag ("car1") || col.gameObject.CompareTag ("car2") || col.gameObject.CompareTag ("car3")) {
				enemyTransform = col.gameObject.transform;
				gameObject.GetComponent<Animator> ().Play ("WalkState");
				enemySpotted = true;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.CompareTag ("car1") || col.gameObject.CompareTag ("car2") || col.gameObject.CompareTag ("car3")) {
			if (timer <= 0) {
				health -= 10;
				timer = 0.1f;
			}
		} else if (col.gameObject.CompareTag ("Bullet")) {
			Debug.Log (col.gameObject.name);
			if (col.gameObject.name == "Bullet1") {
				health -= 25;
			} else if (col.gameObject.name == "Bullet2") {
				health -= 30;
			} else if (col.gameObject.name == "Bullet3") {
				health -= 50;
			} else if (col.gameObject.name == "Bullet4") {
				health -= 75;
			} else if (col.gameObject.name == "Bullet5") {
				health -= 150;
			}
		}
	}

	void Update(){
		if (crate) {
			if (timer > 0) {
				timer -= Time.deltaTime;
			}

			if (health <= 0) {
				if (deathTimer == 0.15f) {
					if (crate) {
						CrateBreak.Play ();
					} else {
						Death.Play ();
					}
					ps.Play ();
					deathTimer -= Time.deltaTime;
				} else if (deathTimer > 0) {
					deathTimer -= Time.deltaTime;
				} else {
					Destroy (gameObject);
				}
			}
		} else {

			if(enemyTransform)
				if (Vector2.Distance (enemyTransform.position, gameObject.transform.position) < 5f)
					attack = true;

			if (enemySpotted) {
				if (timerToStartWalking < 0) {
					if (enemyTransform.position.x > gameObject.transform.position.x) {
						gameObject.transform.localScale = new Vector3 (1, 1, 1);
						gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (10, 0));

					} else {
						gameObject.transform.localScale = new Vector3 (-1, 1, 1);
						gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-10, 0));

					}
					if (attack) {
						gameObject.GetComponent<Animator> ().Play ("AttackState");
						if (timerToDieAfterAttack < 0) {
							gameObject.GetComponent<Animator> ().Play ("DeadState");
							if (timerToDestroy < 0) {
								Death.Play ();
								Destroy (gameObject);
							} else {
								timerToDestroy -= Time.deltaTime;
							}
						} else {
							timerToDieAfterAttack -= Time.deltaTime;
						}
					}
				} else {
					timerToStartWalking -= Time.deltaTime;
				}
			}
		}
	}
}
