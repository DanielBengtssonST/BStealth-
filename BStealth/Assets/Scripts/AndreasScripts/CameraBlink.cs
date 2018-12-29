using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemySight))]
public class CameraBlink : MonoBehaviour
{
    public float timer = 0f;
    public MeshRenderer sightMesh;
	public GameObject warningLight;
    private void Start()
    {
        StartCoroutine("blink");
    }

    IEnumerator blink()
    {
        while (true)
        {
            print("test");
            yield return new WaitForSeconds(timer-1);

			warningLight.SetActive (!warningLight.activeSelf);

			yield return new WaitForSeconds (1);
            GetComponent<EnemySight>().StopAllCoroutines();
            GetComponent<EnemySight>().enabled = !GetComponent<EnemySight>().enabled;
            sightMesh.enabled = !sightMesh.enabled;
        }

    }
}
