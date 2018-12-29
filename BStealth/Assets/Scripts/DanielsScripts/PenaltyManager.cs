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

	CharacterStats playerStats;
	string[][] penaltyNamesList = new string[6][];
	[SerializeField] string[] curPenaltyNames;
	[SerializeField] int curPenaltyMode = 0;

	void Start(){
		
		// [0] = Detection. [][1] = Hit. [][2] = no HP. [][3] = on Restart. [][4] = no life, [][5] = Timer Run Out.
		penaltyNamesList[0] = new string[]{"NoPenalty","TakeDamage","Restart","LoseLife","Gameover", "Restart"};	//Classic
		penaltyNamesList[1] = new string[]{"NoPenalty","TakeDamage","Restart","NoPenalty","NoPenalty","Restart"};	//Modern
		penaltyNamesList[2] = new string[]{"NoPenalty","Restart","NoPenalty","LoseLife","Gameover", "Restart"}; 	//Old arcade
		penaltyNamesList[3] = new string[]{"NoPenalty","Restart","NoPenalty","NoPenalty","NoPenalty","Restart"};	//Meatboy 
		penaltyNamesList[4] = new string[]{"NoPenalty","TakeDamage","GameOver","GameOver","GameOver", "Restart"};	//Hardcore
		penaltyNamesList[5] = new string[]{"Restart","NoPenalty","NoPenalty","NoPenalty","NoPenalty", "Restart"};	//Instant Restart On Detection

		curPenaltyNames = penaltyNamesList [curPenaltyMode];
	}

	public void CallPenalty(int _index){

		Invoke (penaltyNamesList[curPenaltyMode][_index], 0);
	}
	public void UpdatePlayerStats(){

		playerStats = GameObject.FindGameObjectWithTag ("Player").GetComponent<CharacterStats> ();
	}
		
	// List of penalties
	void TakeDamage(){

		playerStats.FindStat ("HP").ChangeValue (-1);
		if (playerStats.FindStat ("HP").depleted) {
			Debug.Log ("Player is ded");
			CallPenalty (2);
		}
	}
	void Restart(){

		if (playerStats.alive) {
			playerStats.alive = false;
			PlayManager.instance.PlayerDeath ();
			CallPenalty (3);
		}
	}
	void LoseLife(){

		playerStats.FindStat ("Lives").ChangeValue (-1);
		if (playerStats.FindStat ("Lives").depleted) {
			CallPenalty (4);
		}
	}
	void GameOver(){

		Debug.Log ("GAME OVER");
		PlayManager.instance.ReloadScene ();
		PlayManager.instance.PauseGame (true);
	}
	void NoPenalty(){

		return;
	}
}