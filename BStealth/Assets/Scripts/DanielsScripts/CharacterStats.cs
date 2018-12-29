using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {

	[SerializeField] List<Stat> stats;

	public bool player = true, alive = true;

	void Start(){

		if (player) {
			PenaltyManager.instance.UpdatePlayerStats ();
			FindStat ("Lives").ChangeValue ((float)PlayManager.instance.playerLives);
		}
	}

	public Stat FindStat(string _statName){

		if (_statName == "") return null;
		
		return stats.Find (Stat => Stat.getName ().Contains (_statName));
	}
}