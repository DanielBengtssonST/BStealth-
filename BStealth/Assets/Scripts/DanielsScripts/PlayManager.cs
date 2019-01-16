using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Pause & Scene reload
public class PlayManager : MonoBehaviour
{

    public static PlayManager instance;
    void Awake()
    {

        if (instance == null)
        {

            instance = this as PlayManager;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);

        playerLives = (int)GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>().FindStat("Lives").getMaxValue();
    }


    //	public List<GameObject> unlockedDoors;

    bool paused;
    [SerializeField] int deathCounter;
    public int playerLives;
    //	[SerializeField] Text playTime;
    public Text livesIndicator, penaltyIndicator;

    void Start()
    {

    }

    void Update()
    {

        //		playTime.text = Time.time.ToString("F2");

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            PauseGame(!paused);
        }
        if (paused && Input.GetKeyDown(KeyCode.R))
        {

            ReloadScene();
        }
        if (paused && Input.GetKeyDown(KeyCode.M))
        {
            GameObject.FindGameObjectWithTag("Checkpoint Handler").GetComponent<CheckpointHandler>().StopAllCoroutines();
            Destroy(GameObject.FindGameObjectWithTag("Checkpoint Handler").GetComponent<CheckpointHandler>().checkpointUI);
            Destroy(GameObject.FindGameObjectWithTag("Checkpoint Handler"));
            LoadScene(0);
            PauseGame(false);
            playerLives = (int)GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>().FindStat("Lives").getMaxValue();
            //			unlockedDoors.Clear ();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Camera.main.GetComponent<CameraBrain>().lookAround = !Camera.main.GetComponent<CameraBrain>().lookAround;
        }
    }

    public void PlayerDeath()
    {
        Time.timeScale = 0.3f;
        Invoke("ReloadScene", 0.25f);
        deathCounter++;
        Debug.Log("You have died " + deathCounter + " times. Stay Determinied!");
    }

    //	public void RememeberDoors(){
    //
    //		for (int i = 0; i < unlockedDoors.Count; i++) {
    //
    //			unlockedDoors [i].gameObject.SetActive (false);
    //		}
    //	}

    public void ReloadScene()
    {
        GameObject.FindGameObjectWithTag("Checkpoint Handler").GetComponent<CheckpointHandler>().StopAllCoroutines();
        Destroy(GameObject.FindGameObjectWithTag("Checkpoint Handler").GetComponent<CheckpointHandler>().checkpointUI);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PauseGame(false);
    }

    public void LoadScene(int _index)
    {

        SceneManager.LoadScene(_index);
    }
    public void LoadScene(string _name)
    {

        SceneManager.LoadScene(_name);
    }
    public int GetCurrentSceneIndex()
    {

        return SceneManager.GetActiveScene().buildIndex;
    }

    public void PauseGame(bool _b)
    {

        paused = _b;
        if (paused)
        {

            Time.timeScale = 0;

        }
        else
        {

            Time.timeScale = 1;
        }
    }
}