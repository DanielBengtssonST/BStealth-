using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(EnemySight))]
public class CameraBlink : MonoBehaviour
{
    public float timer = 0f;
    public MeshRenderer sightMesh;
    public Slider blinkProgress;

    private void Update()
    {
        blinkProgress.value += 1 * Time.timeScale;
        if (blinkProgress.value == blinkProgress.maxValue)
        {
            blinkProgress.value = 0;
            GetComponent<EnemySight>().StopAllCoroutines();
            GetComponent<EnemySight>().enabled = !GetComponent<EnemySight>().enabled;
            sightMesh.enabled = !sightMesh.enabled;
        }
    }
}
