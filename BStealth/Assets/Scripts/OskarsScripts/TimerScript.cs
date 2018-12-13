using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

    [SerializeField]
    Text textUI; 
    [SerializeField]
    float time; //How many secounds the timer is

	// Use this for initialization
	void Start () {
        StartCoroutine(TheTimer());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator TheTimer()
    {
		for(float f = time; f >= 0; f -= (1f/60f) * Time.timeScale)
        {
            textUI.text = f.ToString("F"); //Changes the ui text to the current time
            yield return null;
        }
        textUI.text = "0.00"; //timer sometimes ends att 0.02 so this just changes the text to always be 0.00
        print("time is upp boi"); //executes after timer 
    }
}
