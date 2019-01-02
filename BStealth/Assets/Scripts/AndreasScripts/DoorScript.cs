using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour
{

    bool unlocking = false;
    public GameObject canvasUnlocking;
    public GameObject canvasKey;
    public Slider unlockProgress;
    public bool aquiredKey;
    public List<GameObject> uiElements = new List<GameObject>();



    private void Start()
    {
        //foreach (GameObject uiElement in uiElements)
        //{
        //    uiElement.transform.localRotation = Quaternion.Euler(90, 90, transform.rotation.y + 90);
        //}
        //canvasUnlocking.transform.rotation = Quaternion.Euler(90, 0, 90);
        //canvasKey.transform.rotation = Quaternion.Euler(90, 0, 90);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            unlocking = true;
            LogScript.OpeningDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            unlocking = false;
            LogScript.LeavingDoor();
        }
    }

    private void Update()
    {
        if (!aquiredKey)
        {
            canvasKey.SetActive(unlocking);
            return;
        }
        else
        {
            canvasUnlocking.SetActive(unlocking);
        }
        if (unlocking)
        {
			unlockProgress.value += 1*Time.timeScale;
            if (unlockProgress.value == unlockProgress.maxValue)
            {
                LogScript.OpenDoor();
                Destroy(gameObject);
            }
        }
        else
        {
            unlockProgress.value = 0;
        }
    }

}
