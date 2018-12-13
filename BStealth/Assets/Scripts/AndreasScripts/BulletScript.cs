﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
	GameObject player, shooter;
    public float shotSpeed;
    public float shotLife = 1;
	public float damage = 1;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
		GetComponent<Rigidbody>().AddForce((player.transform.position - transform.position)*shotSpeed,ForceMode.VelocityChange);
		Destroy (gameObject, shotLife);
//      StartCoroutine("DestroyMe", shotLife);
    }

	public void SetShooter(GameObject _shooter){
		shooter = _shooter;
	}

//    IEnumerator DestroyMe(float delay)
//    {
//        yield return new WaitForSeconds(delay);
//        Destroy(gameObject);
//    }

    private void OnTriggerEnter(Collider other)
    {
//		if (other.gameObject != shooter) {
//
//			Destroy(gameObject);			
//		}

        if (other.tag == "Player")
        {
            print("DU BLÄ TRÄFFAD!");
          
			PenaltyManager.instance.CallPenalty (1);
		//	Destroy(gameObject);
        }
//        else if (other.tag == "Wall")
//        {
//	            Destroy(gameObject);
//        }
		Destroy(gameObject);
	}
}