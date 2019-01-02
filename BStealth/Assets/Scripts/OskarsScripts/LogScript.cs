using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LogScript : MonoBehaviour {

    public static LogScript logScript;
    static int numberOfDiscoverd = 0;
    static int numberOfDeaths = 0;
    static int numberOfDamages = 0;
    static int numberOfKeys = 0;
    static int numberOfDoorsOpened = 0;
    static int numberOfTimeOut = 0;
    static int numberOfDoorOpenings = 0;
    static int numberOfDoorsLeft = 0;
    static int numberOfPaused = 0;
    static int numberOfUnpaused = 0;

    void CreateTextfile()
    {
        string path = Application.dataPath + "/Log.txt";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Game start \n \n");
        }
        else if (File.Exists(path))
        {
            string StartString = "Game start \n \n";
            File.AppendAllText(path, StartString);
        }

    }
	
    void Awake()
    {
        CreateTextfile();
        if(logScript == null)
        {
            DontDestroyOnLoad(gameObject);
        }
        else if(logScript != null)
        {
            Destroy(gameObject);
        }
    }

	// Update is called once per frame
	void Update () {
		
	}

    static string MinuteTimer()
    {
        float t = Time.time;
        string minute = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");
        return (minute + ":" + seconds);
    }

    public static void Found()
    {
        string path = Application.dataPath + "/Log.txt";
        string logText = MinuteTimer() + ": player was spotted by an enemy. \n";
        numberOfDiscoverd++;
        File.AppendAllText(path, logText);
    }

    public static void Dead()
    {
        string path = Application.dataPath + "/Log.txt";
        string logText = MinuteTimer() + ": player was killed by an enemy. \n";
        numberOfDeaths++;
        File.AppendAllText(path, logText);
    }

    public static void Damage()
    {
        string path = Application.dataPath + "/Log.txt";
        string logText = MinuteTimer() + ": player was damaged by an enemy. \n";
        numberOfDamages++;
        File.AppendAllText(path, logText);
    }

    public static void FoundKey()
    {
        string path = Application.dataPath + "/Log.txt";
        string logText = MinuteTimer() + ": player picked up a key. \n";
        numberOfKeys++;
        File.AppendAllText(path, logText);
    }

    public static void OpenDoor()
    {
        string path = Application.dataPath + "/Log.txt";
        string logText = MinuteTimer() + ": player opened a door. \n";
        numberOfDoorsOpened++;
        File.AppendAllText(path, logText);
    }

    public static void OpeningDoor()
    {
        string path = Application.dataPath + "/Log.txt";
        string logText = MinuteTimer() + ": player started to open door. \n";
        numberOfDoorOpenings++;
        File.AppendAllText(path, logText);
    }

    public static void LeavingDoor()
    {
        string path = Application.dataPath + "/Log.txt";
        string logText = MinuteTimer() + ": player stoped opening door. \n";
        numberOfDoorsLeft++;
        File.AppendAllText(path, logText);
    }

    public static void GamePaused()
    {
        string path = Application.dataPath + "/Log.txt";
        string logText = MinuteTimer() + ": player paused the game. \n";
        numberOfPaused++;
        File.AppendAllText(path, logText);
    }

    public static void GameUnpaused()
    {
        string path = Application.dataPath + "/Log.txt";
        string logText = MinuteTimer() + ": player unpaused the game. \n";
        numberOfUnpaused++;
        File.AppendAllText(path, logText);
    }

    public static void TimeOut()
    {
        string path = Application.dataPath + "/Log.txt";
        string logText = MinuteTimer() + ": player ran out of time. \n";
        numberOfTimeOut++;
        File.AppendAllText(path, logText);
    }

    public static void Win()
    {
        string path = Application.dataPath + "/Log.txt";
        string logText = MinuteTimer() + ": player got to the exit and won. \nPlayer was found:" + numberOfDiscoverd + " times " +
            "\nPlayer recived damage: " + numberOfDamages + " times " +
            "\nPlayer died: " + numberOfDeaths + " times" +
            "\nPlayer found:" + numberOfKeys + " keys" +
            "\nPlayer opened: " + numberOfDoorsOpened + " doors" +
            "\nPlayer started opening: " + numberOfDoorOpenings + " doors" +
            "\nPlayer stoped opening: " + numberOfDoorsLeft + " doors" +
            "\nPlayer paused: " + numberOfPaused + " times" +
            "\nPlayer unpaused: " + numberOfUnpaused + " times" +
            "\nPlayer timed out: " + numberOfTimeOut + " times";
        File.AppendAllText(path, logText);
    }

    public static void Loose()
    {
        string path = Application.dataPath + "/Log.txt";
        string logText = MinuteTimer() + ": player didn't reach the goal in time. \nPlayer was found:" + numberOfDiscoverd + " times " +
            "\nPlayer recived damage: " + numberOfDamages + " times " +
            "\nPlayer died: " + numberOfDeaths + " times" +
            "\nPlayer found:" + numberOfKeys + " keys" +
            "\nPlayer opened: " + numberOfDoorsOpened + " doors" +
            "\nPlayer started opening: " + numberOfDoorOpenings + " doors" +
            "\nPlayer stoped opening: " + numberOfDoorsLeft + " doors" +
            "\nPlayer paused: " + numberOfPaused + " times" +
            "\nPlayer unpaused: " + numberOfUnpaused + " times" +
            "\nPlayer timed out: " + numberOfTimeOut + " times";
        File.AppendAllText(path, logText);
    }
}
