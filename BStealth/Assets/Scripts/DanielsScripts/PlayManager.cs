using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

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
	[SerializeField] int deathCounter;
//	[SerializeField] Text playTime;

	void Update(){

//		playTime.text = Time.time.ToString("F2");

		if (Input.GetKeyDown (KeyCode.Escape)) {

			PauseGame (!paused);
		}
		if (paused && Input.GetKeyDown (KeyCode.R)) {

			ReloadScene ();
		}
	}

	public void PlayerDeath(){

		Time.timeScale = 0.3f;
		Invoke ("ReloadScene", 0.25f);
		deathCounter++;
		Debug.Log ("You have died " + deathCounter + " times. Stay Determinied!");
	}

	public void ReloadScene(){


		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		PauseGame (false);
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