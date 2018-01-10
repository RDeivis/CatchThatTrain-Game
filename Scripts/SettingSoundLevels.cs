using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingSoundLevels : MonoBehaviour {

	public bool music = true;

	void Update(){
		if (music) {
			int musicVolIndex = PlayerPrefs.GetInt ("PlayerMusicLevel");
			if (musicVolIndex == 0) {
				gameObject.GetComponent<AudioSource> ().volume = 0f;
			} else if (musicVolIndex == 1) {
				gameObject.GetComponent<AudioSource> ().volume = 0.2f;
			} else if (musicVolIndex == 2) {
				gameObject.GetComponent<AudioSource> ().volume = 0.4f;
			} else if (musicVolIndex == 3) {
				gameObject.GetComponent<AudioSource> ().volume = 0.6f;
			} else if (musicVolIndex == 4) {
				gameObject.GetComponent<AudioSource> ().volume = 0.8f;
			} else if (musicVolIndex == 5) {
				gameObject.GetComponent<AudioSource> ().volume = 1f;
			}

		} else {
			int musicVolIndex = PlayerPrefs.GetInt ("PlayerSoundLevel");
			if (musicVolIndex == 0) {
				gameObject.GetComponent<AudioSource> ().volume = 0f;
			} else if (musicVolIndex == 1) {
				gameObject.GetComponent<AudioSource> ().volume = 0.2f;
			} else if (musicVolIndex == 2) {
				gameObject.GetComponent<AudioSource> ().volume = 0.4f;
			} else if (musicVolIndex == 3) {
				gameObject.GetComponent<AudioSource> ().volume = 0.6f;
			} else if (musicVolIndex == 4) {
				gameObject.GetComponent<AudioSource> ().volume = 0.8f;
			} else if (musicVolIndex == 5) {
				gameObject.GetComponent<AudioSource>().volume = 1f;
			}
		}
	}

}
