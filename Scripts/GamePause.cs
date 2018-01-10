using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour {

	public bool pause = false;

	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			if (pause) {
				pause = false;
				Time.timeScale = 1f;
			} else {
				pause = true;
				Time.timeScale = 0f;
			}
		}
	}
}
