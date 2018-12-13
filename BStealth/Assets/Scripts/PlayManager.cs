using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Pause & Scene reload
public class PlayManager : MonoBehaviour {

	public static PlayManager instance;
	void Awake(){

		if (instance == null) {

			instance = this as PlayManager;
		} else {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (this);
	}

	bool paused;

	void Update(){

		if (Input.GetKeyDown (KeyCode.Escape)) {

			PauseGame (!paused);
		}
	}

	public void ReloadScene(){

		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void PauseGame(bool _b){

		paused = _b;
		if (paused) {

			Time.timeScale = 0;

		} else {

			Time.timeScale = 1;
		}
	}
}
