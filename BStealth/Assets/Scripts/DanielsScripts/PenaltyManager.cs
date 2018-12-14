using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Penalty management & List of possible penalites
public class PenaltyManager : MonoBehaviour {

	public static PenaltyManager instance;
	void Awake(){

		if (instance == null) {
			instance = this as PenaltyManager;
		} else {
			Destroy (gameObject);
		}
//		DontDestroyOnLoad (this);
	}

	CharacterStats playerStats;


	string[][] penaltyNamesList = new string[4][];
	[SerializeField] string[] curPenaltyNames;
	[SerializeField] int curPenaltyMode = 0;

	void Start(){

		playerStats = GameObject.FindGameObjectWithTag ("Player").GetComponent<CharacterStats> ();

		penaltyNamesList[0] = new string[]{"NoPenalty","TakeDamage","Restart","LoseLife","Gameover"};	//
		penaltyNamesList[1] = new string[]{"NoPenalty","TakeDamage","Restart","NoPenalty","NoPenalty"};	//Modern
		penaltyNamesList[2] = new string[]{"NoPenalty","Restart","NoPenalty","LoseLife","Gameover"}; 	//Old
		penaltyNamesList[3] = new string[]{"NoPenalty","Restart","NoPenalty","NoPenalty","NoPenalty"};	//Meatboy
		penaltyNamesList[3] = new string[]{"NoPenalty","TakeDamage","GameOver","GameOver","GameOver"};	//Hardcore

		curPenaltyNames = penaltyNamesList [curPenaltyMode];
	}

	public void CallPenalty(int _index){

		Invoke (curPenaltyNames [_index], 0);
	}

	// List of penalties

	// Index: 1
	void TakeDamage(){

		playerStats.FindStat ("HP").ChangeValue (-1);
		if (playerStats.FindStat ("HP").depleated) {
			Debug.Log ("Player is ded");
			CallPenalty (2);
		}
	}
	//Index: 2
	void Restart(){

		PlayManager.instance.PlayerDeath ();
		CallPenalty (3);
	}
	//Index: 3
	void LoseLife(){

		playerStats.FindStat ("Lives").ChangeValue (-1);
		if (playerStats.FindStat ("Lives").depleated) {
			CallPenalty (4);
		}
	}
	//Index: 4
	void GameOver(){

		Debug.Log ("GAME OVER");
		PlayManager.instance.ReloadScene ();
		PlayManager.instance.PauseGame (true);
	}
	//Index: 0
	void NoPenalty(){

		return;
	}
}
