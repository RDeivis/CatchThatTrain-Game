using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D colInfo){
		if (colInfo.CompareTag ("Player")) {
			Debug.Log ("Game Won! :D");
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	}
}
