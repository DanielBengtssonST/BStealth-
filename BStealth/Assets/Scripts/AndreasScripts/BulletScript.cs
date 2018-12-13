﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    GameObject player;
    public float shotSpeed;
    public float shotLife = 1;
	public float damage = 1;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GetComponent<Rigidbody>().AddForce((player.transform.position - transform.position)*shotSpeed,ForceMode.VelocityChange);
        StartCoroutine("DestroyMe", shotLife);
    }

    IEnumerator DestroyMe(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print("DU BLÄ TRÄFFAD!");
          
			other.gameObject.GetComponent<CharacterStats> ().FindStat ("HP").changeValue (-damage);
			Destroy(gameObject);
        }
        else if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }
       
        }
}
