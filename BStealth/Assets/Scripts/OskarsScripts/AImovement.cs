using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class AImovement : MonoBehaviour {

    [SerializeField]
    Transform[] wayPoints; //Agent moves to waypoint in order
    int destPoint = 0;
    NavMeshAgent agent;
    [SerializeField]
    bool foundPlayer = false;
    GameObject thePlayer;
    [SerializeField]
    float normalSpeed = 3.5f;
    [SerializeField]
    float chaseSpeed = 8;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        GoToNextWayPoint();
	}
	
	// Update is called once per frame
	void Update () {
        if (!agent.pathPending && agent.remainingDistance < 0.5f && foundPlayer == false)
            GoToNextWayPoint();
        else if(foundPlayer == true)
            GoToPlayer();
	}

    void GoToNextWayPoint()
    {
        if (wayPoints.Length != 0)
        {
            agent.destination = wayPoints[destPoint].position; //moves to the next waypoint
            destPoint = (destPoint + 1) % wayPoints.Length; //Cykles through the array
            agent.speed = normalSpeed;
        }
    }

    void GoToPlayer()
    {
        agent.destination = new Vector3(thePlayer.transform.position.x, 0, thePlayer.transform.position.z);
        agent.speed = chaseSpeed;
    }
}
