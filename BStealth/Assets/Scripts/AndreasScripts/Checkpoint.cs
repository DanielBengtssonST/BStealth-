using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    
    private void Start()
    {
        GameObject.FindGameObjectWithTag("Checkpoint Handler").GetComponent<CheckpointHandler>().Respawn();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Checkpoint Handler").GetComponent<CheckpointHandler>().UpdateCheckpoint(transform.position);
        }
    }
}
