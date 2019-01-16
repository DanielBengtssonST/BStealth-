using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Vector3 checkpointPosition = new Vector3();
    public bool useGameobjectPosition = false;
  

    private void Start()
    {
        GameObject.FindGameObjectWithTag("Checkpoint Handler").GetComponent<CheckpointHandler>().Respawn();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (useGameobjectPosition)
            {
                GameObject.FindGameObjectWithTag("Checkpoint Handler").GetComponent<CheckpointHandler>().UpdateCheckpoint(transform.position);
            }
            else
            {
                GameObject.FindGameObjectWithTag("Checkpoint Handler").GetComponent<CheckpointHandler>().UpdateCheckpoint(checkpointPosition);
            }
        }
    }
}
