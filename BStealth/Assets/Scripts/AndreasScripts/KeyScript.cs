﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{

    public DoorScript door;
    public GameObject keyIndicator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (door != null)
            {
                door.aquiredKey = true;
                GameObject.FindGameObjectWithTag("Checkpoint Handler").GetComponent<CheckpointHandler>().tempkeys.Add(gameObject.name);
                keyIndicator.SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}
