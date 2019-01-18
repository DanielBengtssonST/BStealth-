using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnglePingPong : MonoBehaviour
{
    public bool PingPongActive = true;
	public float angleA, angleB; 								//The two stop and start angles to rotate between. 
	public float startAngle; 	
//	[Tooltip("Displays angle Range between Angle A & Angle B")]
//	public float angleRange;
//	[Range(0,100)] public int startRotation;
	[Range(0, 90)] public float rotationSpeed;  				//Recommended Range for script stability. (Sometimes skips wait delay when rotation speed is too high)
    public float waitDelay;                     //Delay how long to wait before rotating back.

	[SerializeField]float curAngle, t;	//DEBUG purposes


    void Start()
    {
//		t = ((angleB - (angleA))*startRotation/100);					//(New Start Angle method)
//		angleRange = angleB - angleA;	//Calculates range between angle A & B 	(DEBUG purposes)
//
		t = Mathf.Clamp(startAngle - angleA, 0, angleB - angleA);		//Sets angle to Start Angle and clamps it between angle A & B-A 
    }

    // Update is called once per frame
    void Update()
    {
        if (PingPongActive){

			//Pingpongs curAngle between Angle A & B-A by deltaTime and Rotation Speed
            curAngle = (angleA + Mathf.PingPong(t += Time.deltaTime * rotationSpeed, angleB - angleA));

			//Checks if end angle has been reached, and pauses pingpong by waitDelay 
			if (Mathf.Round(curAngle) - (rotationSpeed*0.03) <= angleA || Mathf.Round(curAngle) + (rotationSpeed*0.03) >= angleB)
            {
                PingPongActive = false;
				Invoke("StartPingPong", waitDelay);
            }

			//Sets gameObjects rotation to curRotation
            gameObject.transform.rotation = Quaternion.Euler(0, curAngle, 0);
        }
    }
	//Restarts Pingpong
    void StartPingPong()
    {
		t += 1+rotationSpeed *0.06f;
		if (t > (angleB - angleA) * 2) {
			t = 1+rotationSpeed *0.03f;		
		} 
		PingPongActive = true;
    }
}