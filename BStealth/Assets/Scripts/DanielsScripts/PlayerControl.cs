using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	MovementCore movement;
	CharacterStats playerStats;

	float baseMovementSpeed = 10;		
	public float bonusMovementSpeed = 20;

	void Awake(){
		
		movement = GetComponent<MovementCore> ();
		playerStats = GetComponent<CharacterStats> ();
	}
		
	// Update is called once per frame
	void Update () {

		if (playerStats.alive) {

			movement.curVelocity = new Vector3(Input.GetAxis("Horizontal"), 0 , Input.GetAxis("Vertical")) * (baseMovementSpeed + bonusMovementSpeed);

//			//Basic horizontal movement 
//			movement.curXVelocity = (Input.GetAxis ("Horizontal") * (baseMovementSpeed + bonusMovementSpeed));
//			movement.curZVelocity = (Input.GetAxis ("Vertical") * (baseMovementSpeed + bonusMovementSpeed));
		}
	}
}