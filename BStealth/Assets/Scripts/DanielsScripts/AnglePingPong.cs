using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnglePingPong : MonoBehaviour {

	public bool PingPongActive = true;
	public float angleA, angleB;				//The two stop and start angles to rotate between. 
	[Range(0,45)] public float rotationSpeed; 	//Recommended Range for script stability. (Sometimes skips wait delay when rotation speed is too high)
	public float waitDelay;						//Delay how long to wait before rotating back.
	float curAngle, t;
		
	// Update is called once per frame
	void Update () {

		if (PingPongActive) {

			curAngle = (angleA + Mathf.PingPong (t += Time.deltaTime * rotationSpeed, angleB - angleA));

			if (Mathf.Round(curAngle)-0.75f <= angleA || Mathf.Round(curAngle)+0.75f >= angleB) {

				PingPongActive = false;
				Invoke ("LookAgain", waitDelay);
			}
			gameObject.transform.rotation = Quaternion.Euler (0, curAngle, 0);
		}
	}
	void LookAgain(){

		PingPongActive = true;
		t++;
	}
}