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
    int NumberOfDoorsOpened = 0;

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
        logScript.numberOfDiscoverd++;
        File.AppendAllText(path, logText);
    }

    public static void Dead()
    {
        string path = Application.dataPath + "/Log.txt";
        string logText = MinuteTimer() + ": player was killed by an enemy. \n";
        logScript.numberOfDeaths++;
        File.AppendAllText(path, logText);
    }

    public static void Damage()
    {
        string path = Application.dataPath + "/Log.txt";
        string logText = MinuteTimer() + ": player was damaged by an enemy. \n";
        logScript.numberOfDamages++;
        File.AppendAllText(path, logText);
    }

    public static void FoundKey()
    {
        string path = Application.dataPath + "/Log.txt";
        string logText = MinuteTimer() + ": player picked up a key. \n";
        logScript.numberOfKeys++;
        File.AppendAllText(path, logText);
    }

    public static void OpenDoor()
    {
        string path = Application.dataPath + "/Log.txt";
        string logText = MinuteTimer() + ": player opened a door. \n";
        logScript.NumberOfDoorsOpened++;
        File.AppendAllText(path, logText);
    }

    public static void Win()
    {
        string path = Application.dataPath + "/Log.txt";
        string logText = MinuteTimer() + ": player got to the exit and won. \nPlyer was found:" + logScript.numberOfDiscoverd + " times " +
            "\nPlayer recived damage: " + logScript.numberOfDamages + " times " +
            "\nPlayer died: " + logScript.numberOfDeaths + " times" +
            "\nPlyer found:" + logScript.numberOfKeys + " keys " +
            "\nPlayer opened: " + logScript.NumberOfDoorsOpened + " doors";
        File.AppendAllText(path, logText);
    }
}
