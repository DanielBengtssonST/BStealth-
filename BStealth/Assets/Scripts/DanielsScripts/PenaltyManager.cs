using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Penalty management & List of possible penalites
public class PenaltyManager : MonoBehaviour
{

    public static PenaltyManager instance;
    void Awake()
    {

        if (instance == null)
        {
            instance = this as PenaltyManager;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);

        if (Randomize) PenaltyRandomizer();
    }


    public bool Randomize = true;
    CharacterStats playerStats;
    string[][] penaltyNamesList = new string[7][];
    [SerializeField] string[] curPenaltyNames;
    [SerializeField] int curPenaltyMode = 0;

    public List<int> penaltyModesToRandomize;
    public List<int> curPenaltyModes;
    int penaltyModeIndex = 0;


    void Start()
    {

        // [0] = Detection. [][1] = Hit. [][2] = no HP. [][3] = on Restart. [][4] = no life, [][5] = Timer Run Out.
        penaltyNamesList[0] = new string[] { "NoPenalty", "TakeDamage", "Restart", "LoseLife", "GameOver", "Restart", "Classic" };          //Classic
        penaltyNamesList[1] = new string[] { "NoPenalty", "TakeDamage", "Restart", "NoPenalty", "NoPenalty", "Restart", "Modern" };         //Modern
        penaltyNamesList[2] = new string[] { "NoPenalty", "Restart", "NoPenalty", "LoseLife", "GameOver", "Restart", "Arcade" };            //Old arcade
        penaltyNamesList[3] = new string[] { "NoPenalty", "Restart", "NoPenalty", "NoPenalty", "NoPenalty", "Restart", "Meatboy" };         //Meatboy 
        penaltyNamesList[4] = new string[] { "NoPenalty", "TakeDamage", "GameOver", "GameOver", "GameOver", "GameOver", "Hardcore" };       //Hardcore
        penaltyNamesList[5] = new string[] { "Restart", "NoPenalty", "NoPenalty", "LoseLife", "NoPenalty", "Restart", "Instant Death" };    //Instant Restart On Detection

        curPenaltyMode = curPenaltyModes[penaltyModeIndex];
        curPenaltyNames = penaltyNamesList[curPenaltyMode];
    }

    public void CallPenalty(int _index)
    {

        Invoke(penaltyNamesList[curPenaltyMode][_index], 0);
    }
    public void UpdatePlayerStats()
    {

        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
    }
    public void NextPenaltyMode()
    {

        penaltyModeIndex = (PlayManager.instance.GetCurrentSceneIndex() - 1);

        //		penaltyModeIndex++;
        //		if (penaltyModeIndex >= curPenaltyModes.Count) {
        //			penaltyModeIndex = 0;
        //		}
        //
        curPenaltyMode = curPenaltyModes[penaltyModeIndex];
        curPenaltyNames = penaltyNamesList[curPenaltyMode];
        PlayManager.instance.penaltyIndicator.text = penaltyNamesList[curPenaltyMode][6];

        if (penaltyNamesList[curPenaltyMode][6] == "Arcade" || penaltyNamesList[curPenaltyMode][6] == "Meatboy" || penaltyNamesList[curPenaltyMode][6] == "Instant Death")
        {

            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Canvas>().gameObject.SetActive(false);
        }
        else
        {
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Canvas>().gameObject.SetActive(true);
        }

        if (penaltyNamesList[curPenaltyMode][6] == "Classic" || penaltyNamesList[curPenaltyMode][6] == "Arcade")
        {

            PlayManager.instance.livesIndicator.gameObject.SetActive(true);
        }
        else
        {
            PlayManager.instance.livesIndicator.gameObject.SetActive(false);
        }

    }

    void PenaltyRandomizer()
    {

        curPenaltyModes.Clear();
        int _count = penaltyModesToRandomize.Count;

        for (int i = 0; i < _count; i++)
        {

            int _random = Random.Range(0, penaltyModesToRandomize.Count);
            curPenaltyModes.Add(penaltyModesToRandomize[_random]);
            penaltyModesToRandomize.RemoveAt(_random);
        }

        //for LVL 3 Hardcore Edition
        curPenaltyModes.Add(2);

    }

    // List of penalties
    void TakeDamage()
    {

        playerStats.FindStat("HP").ChangeValue(-1);
        if (playerStats.FindStat("HP").depleted)
        {
            CallPenalty(2);
        }
    }
    void Restart()
    {

        if (playerStats.alive)
        {
            playerStats.alive = false;

            if (penaltyNamesList[curPenaltyMode][3] == "LoseLife")
            {

                CallPenalty(3);
            }
            else
            {
                PlayManager.instance.PlayerDeath();
            }
        }
    }
    void LoseLife()
    {

        playerStats.FindStat("Lives").ChangeValue(-1);
        PlayManager.instance.playerLives = (int)playerStats.FindStat("Lives").getValue();

        if (playerStats.FindStat("Lives").depleted)
        {
            CallPenalty(4);
        }
        else
        {
            PlayManager.instance.PlayerDeath();
        }
    }
    void GameOver()
    {
        Destroy(GameObject.FindGameObjectWithTag("Checkpoint Handler"));
        PlayManager.instance.LoadScene(0);
        PlayManager.instance.playerLives = (int)playerStats.FindStat("Lives").getMaxValue();
        //		PlayManager.instance.unlockedDoors.Clear ();
    }
    void NoPenalty()
    {

        return;
    }
}