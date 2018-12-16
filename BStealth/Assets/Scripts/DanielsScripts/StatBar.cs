using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatBar : MonoBehaviour {

	Stat barStat;
	[SerializeField] string barStatName;
	float size;

	// Use this for initialization
	void Start () {

		barStat = GetComponentInParent<CharacterStats> ().FindStat (barStatName);
		size = transform.localScale.x;
	}

	public void UpdateBar(){

		transform.localScale = new Vector3 (size * ((barStat.getValue () / barStat.getMaxValue ())), transform.localScale.y, transform.localScale.z);
	}
}
