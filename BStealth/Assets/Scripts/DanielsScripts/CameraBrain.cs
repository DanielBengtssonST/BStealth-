using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Smoothly follows a target gameobject at an offset
//Can follow X(0), Y(1) & Z(2) axis
public class CameraBrain: MonoBehaviour {

	public GameObject target; 									//The target game object
	public Vector3 targetPos;

	[Header("Follow")]
	public bool follow = true;									//If Camera should follow
	public bool lookAround = false;
	public bool[] followXYZ = new bool[]{true, true, true};		//If camera should follow the X(0), Y(1) and/or Z(2) axis
	public Vector3 cameraFollowOffset;							//The offset by which the camera should follow
	public float followTime;									//The time it takes for the camera to move to a new target position

	public Vector3 cameraLookOffset;
	public float cameraLookScale;


	Vector3 refFollowvelocity = Vector3.zero;

	// Use this for initialization
	void Start () {

		if (!target) {
			target = GameObject.FindWithTag ("Player");
		}
		targetPos = transform.position;
	}

	// Update is called once per frame
	void FixedUpdate () {

		if (follow) {

			if (lookAround) {

				cameraLookOffset = ((Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z)) - transform.position) * cameraLookScale);
			} else {
				cameraLookOffset = Vector3.zero;
			}

			for (int i = 0; i < 3; i++) {

				if (followXYZ [i]) {

					if ((target.transform.position [i] + cameraFollowOffset [i]) > transform.position [i] ||
					   (target.transform.position [i] + cameraFollowOffset [i]) < transform.position [i]) {

						targetPos [i] = target.transform.position [i] + cameraFollowOffset [i];
					}
				}
			}
			transform.position = Vector3.SmoothDamp (transform.position, (targetPos+cameraLookOffset), ref refFollowvelocity, followTime);
		}
	}
				
	public void SetFollowXYZ(int _i, bool _b){

		followXYZ[_i] = _b;
		targetPos[_i] = transform.position[_i];
	}
}