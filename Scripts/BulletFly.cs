using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour {

	private Vector3 target;
	private bool ready = false;

	private Vector3 velocity = new Vector3(1, 0, 0);

	void Update () {
		if (ready)
			gameObject.transform.position = Vector3.SmoothDamp (gameObject.transform.position, target, ref velocity, 0.1f);
		if (Vector3.Distance (gameObject.transform.position, target) < 0.1f)
			Destroy (gameObject);
	}

	public void SetTarget(Vector3 shootable){
		target = shootable;
		ready = true;
	}

	void OnCollisionEnter2D(Collision2D col){
		Destroy (gameObject);
	}
}
