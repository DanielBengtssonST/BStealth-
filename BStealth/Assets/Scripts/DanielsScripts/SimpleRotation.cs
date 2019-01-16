using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotation : MonoBehaviour {

	public bool rotating;
	public float XRotation, YRotation, ZRotation;

	// Update is called once per frame
	void Update () {
	
		if (rotating){

			transform.Rotate ((new Vector3(XRotation,YRotation,ZRotation)*Time.timeScale));
		}
	}
}