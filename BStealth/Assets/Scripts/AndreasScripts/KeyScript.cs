using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour {

    public DoorScript door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            door.aquiredKey = true;
            Destroy(gameObject);
        }
    }
}
