using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//
public class TimerScript : MonoBehaviour {

    [SerializeField]
    Text textUI; 
    [SerializeField]
    float time; //How many secounds the timer is

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(time >= 0)
        {
            time -= Time.deltaTime; //is the actual timer
            string minutes = ((int)time / 60).ToString(); //Allows for minutes to be shown so it's not just seconds
            string seconds = (time % 60).ToString("f2"); //Displayes the remaing seconds in the minut and the decimals
            textUI.text = string.Format("{0:00}:{1:00} ", minutes, seconds); //changes the ui text to what the timer is
        }
	}
}
