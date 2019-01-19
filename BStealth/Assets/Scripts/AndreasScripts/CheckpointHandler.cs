using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckpointHandler : MonoBehaviour
{
    [SerializeField]
    GameObject checkpointUIPrefab;
    [HideInInspector]
    public GameObject checkpointUI;
    [SerializeField]
    float fadeSpeed = 0;
    [SerializeField]
    float fadeDelay = 0;

    Vector3 respawnPoint = new Vector3(0, 0.5f, 0);

    [HideInInspector]
    public List<string> tempkeys = new List<string>();
    List<string> keys = new List<string>();
    

    public static CheckpointHandler instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this as CheckpointHandler;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

    public void ResetTempKeys()
    {
        tempkeys.Clear();
        foreach (string key in keys)
        {
            tempkeys.Add(key);
        }
    }
    public void Respawn()
    {
        tempkeys.Clear();
        GameObject.FindGameObjectWithTag("Player").transform.position = respawnPoint;
        if (keys.Count > 0)
        {
            foreach (string key in keys)
            {
                if (GameObject.Find(key))
                {
                    GameObject.Find(key).GetComponent<KeyScript>().door.aquiredKey = true;
                    GameObject.Find(key).GetComponent<KeyScript>().keyIndicator.SetActive(true);
                    Destroy(GameObject.Find(key));
                }
            }
        }
    }

    public void UpdateCheckpoint(Vector3 checkpoint)
    {
        if (checkpointUI == null)
        {
            foreach (string tempkey in tempkeys)
            {
                if (!keys.Contains(tempkey))
                {
                    keys.Add(tempkey);
                }
            }
            respawnPoint = checkpoint;
            ShowUI();
        }
    }

    void ShowUI()
    {
        checkpointUI = Instantiate(checkpointUIPrefab, GameObject.FindGameObjectWithTag("Main Canvas").transform);
        StartCoroutine("FadeUI");
    }

    IEnumerator FadeUI()
    {
        yield return new WaitForSecondsRealtime(fadeDelay);
        for (float f = 1f; f >= 0f; f -= fadeSpeed)
        {
            checkpointUI.GetComponent<Text>().color = new Color(0, 0, 0, f);
            yield return new WaitForEndOfFrame();
        }
        Destroy(checkpointUI);
    }



}
