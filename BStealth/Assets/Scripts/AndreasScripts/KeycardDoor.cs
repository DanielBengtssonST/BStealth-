using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycardDoor : MonoBehaviour
{
    public GameObject keycardDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            keycardDoor.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            keycardDoor.SetActive(true);
        }
    }
}
