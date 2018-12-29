using System.Collections;
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
            if (switchUsingID)
            {
                SceneManager.LoadScene(nextSceneID);

            }
            else
            {
                SceneManager.LoadScene(nextSceneName);
            }
            LogScript.Win();
        }
    }
}
