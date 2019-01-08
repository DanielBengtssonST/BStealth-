using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LogScript : MonoBehaviour {

    public static LogScript logScript;
    int numberOfDiscoverd = 0;
    int numberOfDeaths = 0;
    int numberOfDamages = 0;
    int numberOfKeys = 0;
    int numberOfDoorsOpened = 0;
    int numberOfTimeOut = 0;
    int numberOfDoorOpenings = 0;
    int numberOfDoorsLeft = 0;
    int numberOfPaused = 0;

    void CreateTextfile()
    {
        string path = Application.dataPath + "/Log.txt";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Game start \n \n");
        }
    }
	
    void Awake()
    {
        CreateTextfile();
        if(logScript == null)
        {
            DontDestroyOnLoad(gameObject);
            logScript = this;

        }
        else if(logScript != this)
        {
            Destroy(gameObject);
        }
    }

	// Update is called once per frame
	void Update () {
		
	}

    string MinuteTimer()
    {
        float t = Time.time;
        string minute = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");
        return (minute + ":" + seconds);
    }

    public void Found()
    {
        string path = Application.dataPath + "/Log.txt";
        string logText = MinuteTimer() + ": player was spotted by an enemy. \n";
        numberOfDiscoverd++;
        File.AppendAllText(path, logText);
    }

    public void Dead()
    {
        string path = Application.dataPath + "/Log.txt";
        string logText = MinuteTimer() + ": player was killed by an enemy. \n";
        numberOfDeaths++;
        File.AppendAllText(path, logText);
    }

    public void Damage()
    {
        string path = Application.dataPath + "/Log.txt";
        string logText = MinuteTimer() + ": player was damaged by an enemy. \n";
        numberOfDamages++;
        File.AppendAllText(path, logText);
    }

    public void FoundKey()
    {
        string path = Application.dataPath + "/Log.txt";
        string logText = MinuteTimer() + ": player picked up a key. \n";
        numberOfKeys++;
        File.AppendAllText(path, logText);
    }

    public void OpenDoor()
    {
        string path = Application.dataPath + "/Log.txt";
        string logText = MinuteTimer() + ": player opened a door. \n";
        numberOfDoorsOpened++;
        File.AppendAllText(path, logText);
    }

    public void OpeningDoor()
    {
        string path = Application.dataPath + "/Log.txt";
        string logText = MinuteTimer() + ": player started to open door. \n";
        numberOfDoorOpenings++;
        File.AppendAllText(path, logText);
    }

    public void LeavingDoor()
    {
        string path = Application.dataPath + "/Log.txt";
        string logText = MinuteTimer() + ": player stoped opening door. \n";
        numberOfDoorsLeft++;
        File.AppendAllText(path, logText);
    }

    public void GamePaused()
    {
        string path = Application.dataPath + "/Log.txt";
        string logText = MinuteTimer() + ": player pressed paus. \n";
        numberOfPaused++;
        File.AppendAllText(path, logText);
    }

    public void TimeOut()
    {
        string path = Application.dataPath + "/Log.txt";
        string logText = MinuteTimer() + ": player ran out of time. \n";
        numberOfTimeOut++;
        File.AppendAllText(path, logText);
    }

    public void Win()
    {
        string path = Application.dataPath + "/Log.txt";
        string logText = MinuteTimer() + ": player got to the exit and won. \nPlayer was found:" + numberOfDiscoverd + " times " +
            "\nPlayer recived damage: " + numberOfDamages + " times " +
            "\nPlayer died: " + numberOfDeaths + " times" +
            "\nPlayer found: " + numberOfKeys + " keys" +
            "\nPlayer opened: " + numberOfDoorsOpened + " doors" +
            "\nPlayer started opening: " + numberOfDoorOpenings + " doors" +
            "\nPlayer stoped opening: " + numberOfDoorsLeft + " doors" +
            "\nPlayer paused: " + numberOfPaused + " times" +
            "\nPlayer timed out: " + numberOfTimeOut + " times";
        File.AppendAllText(path, logText);
    }

    public void Loose()
    {
        string path = Application.dataPath + "/Log.txt";
        string logText = MinuteTimer() + ": player didn't reach the goal in time. \nPlayer was found:" + numberOfDiscoverd + " times " +
            "\nPlayer recived damage: " + numberOfDamages + " times " +
            "\nPlayer died: " + numberOfDeaths + " times" +
            "\nPlayer found: " + numberOfKeys + " keys" +
            "\nPlayer opened: " + numberOfDoorsOpened + " doors" +
            "\nPlayer started opening: " + numberOfDoorOpenings + " doors" +
            "\nPlayer stoped opening: " + numberOfDoorsLeft + " doors" +
            "\nPlayer paused: " + numberOfPaused + " times" +
            "\nPlayer timed out: " + numberOfTimeOut + " times";
        File.AppendAllText(path, logText);
    }
}
