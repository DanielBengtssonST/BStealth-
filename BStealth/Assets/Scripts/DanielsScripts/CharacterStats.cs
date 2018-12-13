﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {

	public List<Stat> stats;

	void Start(){

	}

	public Stat FindStat(string _statName){

		return stats.Find (Stat => Stat.getName ().Contains (_statName));
	}
}
