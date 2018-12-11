﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Smoothly follows a target gameobject at an offset
//Can follow X(0), Y(1) & Z(2) axis
public class CameraBrain: MonoBehaviour {

	public GameObject target; 									//The target game object
	Vector3 targetPos;

	[Header("Follow")]
	public bool follow = true;									//If Camera should follow
	public bool[] followXYZ = new bool[]{true, true, true};		//If camera should follow the X(0), Y(1) and/or Z(2) axis
	public Vector3 cameraFollowOffset;							//The offset by which the camera should follow
	public float followTime;									//The time it takes for the camera to move to a new target position

	Vector3 refFollowvelocity = Vector3.zero;

	// Use this for initialization
	void Start () {

		targetPos = transform.position;
	}

	// Update is called once per frame
	void FixedUpdate () {

		if (follow) {

			for (int i = 0; i < 3; i++) {

				if (followXYZ [i]) {

					if ((target.transform.position [i] + cameraFollowOffset [i]) > transform.position [i] ||
					   (target.transform.position [i] + cameraFollowOffset [i]) < transform.position [i]) {

						targetPos [i] = target.transform.position [i] + cameraFollowOffset [i];
					}
				}
			}
			transform.position = Vector3.SmoothDamp (transform.position, targetPos, ref refFollowvelocity, followTime);
		}
	}
				
	public void SetFollowXYZ(int _i, bool _b){

		followXYZ[_i] = _b;
		targetPos[_i] = transform.position[_i];
	}
}