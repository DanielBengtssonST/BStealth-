using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSpin : MonoBehaviour
{
    public SimpleRotation rotation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            rotation.rotating = true;
        }
    }
}
