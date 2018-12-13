using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {

	public Stat[] stats;


	void Start(){

		stats [0].changeValue (100);
	}

}
