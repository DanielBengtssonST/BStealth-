using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {

	[SerializeField] List<Stat> stats;

	public bool alive = true;

	void Start(){

		PenaltyManager.instance.UpdatePlayerStats ();
	}

	public Stat FindStat(string _statName){

		if (_statName == "") return null;
		
		return stats.Find (Stat => Stat.getName ().Contains (_statName));
	}
}