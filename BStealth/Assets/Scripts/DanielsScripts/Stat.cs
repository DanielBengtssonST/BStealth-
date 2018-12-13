using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat {

	[SerializeField] string name;
	[SerializeField] float maxValue;
	[SerializeField] float curValue;

	public void changeValue(float _value){

		curValue = Mathf.Min (curValue += _value, maxValue);

	 	if (curValue <= 0) {

			curValue = 0;

			Debug.Log (name + " reached " + curValue);
			PlayManager.instance.PauseGame (true);
		}
	}

	public string getName(){

		return name;
	}
}
