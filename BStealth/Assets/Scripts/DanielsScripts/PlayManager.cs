﻿using System.Collections;
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
	public int playerLives;
//	[SerializeField] Text playTime;

	void Start(){

		playerLives = (int)GameObject.FindGameObjectWithTag ("Player").GetComponent<CharacterStats> ().FindStat ("Lives").getMaxValue ();
	}

	void Update(){

//		playTime.text = Time.time.ToString("F2");

		if (Input.GetKeyDown (KeyCode.Escape)) {

			PauseGame (!paused);
		}
		if (paused && Input.GetKeyDown (KeyCode.R)) {

			ReloadScene ();
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			Camera.main.GetComponent<CameraBrain> ().lookAround = !Camera.main.GetComponent<CameraBrain> ().lookAround;
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

	public void LoadScene(int _index){

		SceneManager.LoadScene (_index);
	}
	public void LoadScene(string _name){

		SceneManager.LoadScene (_name);
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