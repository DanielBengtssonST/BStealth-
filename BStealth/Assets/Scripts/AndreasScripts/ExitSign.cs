﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitSign : MonoBehaviour
{

    public string nextSceneName;
    public int nextSceneID;
    public bool switchUsingID;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
			PlayManager.instance.playerLives = (int)other.gameObject.GetComponent<CharacterStats> ().FindStat ("Lives").getMaxValue ();
            GameObject.FindGameObjectWithTag("Checkpoint Handler").GetComponent<CheckpointHandler>().StopAllCoroutines();
            Destroy(GameObject.FindGameObjectWithTag("Checkpoint Handler").GetComponent<CheckpointHandler>().checkpointUI);
            Destroy(GameObject.FindGameObjectWithTag("Checkpoint Handler"));
            if (switchUsingID)
            {
                SceneManager.LoadScene(nextSceneID);

            }
            else
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}
