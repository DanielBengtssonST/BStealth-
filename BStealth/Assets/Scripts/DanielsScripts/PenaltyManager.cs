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
		DontDestroyOnLoad (this);
	}

	[SerializeField] string[] penaltyNames = new string[]{"NoPenalty","TakeDamage","LoseLife","Restart","Gameover"};
	CharacterStats playerStats;

	void Start(){

		playerStats = GameObject.FindGameObjectWithTag ("Player").GetComponent<CharacterStats> ();

//		penaltyNames[0] = "NoPenalty";
//		penaltyNames[1] = "TakeDamage";
//		penaltyNames[2] = "LoseLife";
//		penaltyNames[3] = "Restart";
//		penaltyNames[4] = "GameOver";

	}


	public void CallPenalty(int _index){

		Invoke (penaltyNames [_index], 0);
	}

	// List of penalties

	// Index: 1
	void TakeDamage(){

		playerStats.FindStat ("HP").ChangeValue (-1);
		if (playerStats.FindStat ("HP").depleated) {
			CallPenalty (2);
		}
	}
	//Index: 2
	void LoseLife(){

		playerStats.FindStat ("Lives").ChangeValue (-1);
		if (playerStats.FindStat ("Lives").depleated) {
			CallPenalty (3);
		}
	}
	//Index: 3
	void Restart(){

		PlayManager.instance.ReloadScene ();
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
