using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour
{

    bool unlocking = false;
    public GameObject canvas;
    public Slider unlockProgress;
    public bool aquiredKey;



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            unlocking = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            unlocking = false;
        }
    }

    private void Update()
    {
        if (!aquiredKey)
        {
            return;
        }
        if (unlocking)
        {
            unlockProgress.value++;
            if (unlockProgress.value == unlockProgress.maxValue)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            unlockProgress.value = 0;
        }
        canvas.SetActive(unlocking);
        
    }

}
