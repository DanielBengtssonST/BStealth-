﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat {

	[SerializeField] string name;
	[SerializeField] float maxValue;
	[SerializeField] float curValue;
	public bool depleted;
	StatBar bar;

	public void ChangeValue(float _value){

		curValue = Mathf.Min (curValue += _value, maxValue);
		CheckValue ();
		if (bar) {
			bar.UpdateBar ();
		}
	}

	void CheckValue(){

		if (curValue <= 0) {

			curValue = 0;
			depleted = true;
		} else {
			depleted = false;
		}
	}

	public string getName(){

		return name;
	}
	public float getValue (){

		return curValue;
	}
	public float getMaxValue(){

		return maxValue;
	}
	public void SetStatBar(StatBar _statBar){

		bar = _statBar;
	}
}
