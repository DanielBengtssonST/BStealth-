using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	MovementCore movement;

	float baseMovementSpeed = 10;		
	public float bonusMovementSpeed = 20;

	void Awake(){
		
		movement = GetComponent<MovementCore> ();
	}
		
	// Update is called once per frame
	void Update () {

		//Basic horizontal movement 
		movement.curXVelocity = (Input.GetAxis ("Horizontal") * (baseMovementSpeed + bonusMovementSpeed));
		movement.curZVelocity = (Input.GetAxis ("Vertical") * (baseMovementSpeed + bonusMovementSpeed));
	}
}