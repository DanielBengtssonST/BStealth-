using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatBar : MonoBehaviour {

	Stat barStat;
	[SerializeField] Slider barSlider;
	[SerializeField] string barStatName;

	// Use this for initialization
	void Start () {

		//Assigns local slider (if one exists) as barSlider if no slider is assigned 
		if (!barSlider && GetComponent<Slider>() != null) {
			barSlider = GetComponent<Slider> ();
		}
		//Assigned bar stat from corresponding stat
		barStat = GetComponentInParent<CharacterStats> ().FindStat (barStatName);
		barStat.SetStatBar (this);
		barSlider.minValue = 0;
		barSlider.maxValue = barStat.getMaxValue ();
		barSlider.value = barStat.getValue ();
	}

	public void UpdateBar(){

		barSlider.value = barStat.getValue ();
	}
}