using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenaltyManager : MonoBehaviour {

	public static PenaltyManager instance;
	void Awake(){

		if (instance == null) {
			instance = this as PenaltyManager;
		} else {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (this);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
