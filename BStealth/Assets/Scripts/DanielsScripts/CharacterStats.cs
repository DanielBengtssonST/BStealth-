using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour {

	[SerializeField] List<Stat> stats;

	public bool player = true, alive = true;

	void Start(){

		if (player) {
			PenaltyManager.instance.UpdatePlayerStats ();
			FindStat ("Lives").ChangeValue ((float)PlayManager.instance.playerLives);

			PlayManager.instance.livesIndicator = GameObject.Find ("LivesIndicator").GetComponent<Text> ();
			PlayManager.instance.livesIndicator.text = "Lives: " + PlayManager.instance.playerLives.ToString ();
		}
		PlayManager.instance.penaltyIndicator = GameObject.Find ("PenaltyIndicator").GetComponent<Text> ();
		PenaltyManager.instance.NextPenaltyMode ();
//		PlayManager.instance.RememeberDoors ();

	}

	public Stat FindStat(string _statName){

		if (_statName == "") return null;
		
		return stats.Find (Stat => Stat.getName ().Contains (_statName));
	}
}