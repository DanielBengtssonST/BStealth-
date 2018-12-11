﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class AImovement : MonoBehaviour {

    [SerializeField]
    Transform[] wayPoints; //Agent moves to waypoint in order
    int destPoint = 0;
    NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        GoToNextPoint();
	}
	
	// Update is called once per frame
	void Update () {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GoToNextPoint();
	}

    void GoToNextPoint()
    {
        if (wayPoints.Length != 0)
        {
            agent.destination = wayPoints[destPoint].position; //moves to the next waypoint
            destPoint = (destPoint + 1) % wayPoints.Length; //Cykles through the array
        }
    }
}
