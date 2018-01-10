using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public void StartPause(){
		Time.timeScale = 0f;
	}

	public void StopPause(){
		Time.timeScale = 1f;
	}

	public void ResetLevel(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void ReturnToMainMenu(){
		SceneManager.LoadScene (0);
	}
}
