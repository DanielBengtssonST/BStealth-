using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
	GameObject player; 
	GameObject shooter;
    public float shotSpeed;
    public float shotLife = 1;
	public float damage = 1;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
		GetComponent<Rigidbody>().AddForce((player.transform.position - transform.position).normalized * shotSpeed,ForceMode.VelocityChange);
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

		if (other.CompareTag("Player"))
        {
            print("DU BLÄ TRÄFFAD!");
          
			//Playing around with a knockback effect /Daniel
//			other.gameObject.GetComponent<MovementCore> ().ApplyKnockbackForce ((player.transform.position - shooter.transform.position).normalized * 40f,false);

			PenaltyManager.instance.CallPenalty (1);
			Destroy(gameObject);
        }
        else if (other.tag == "Wall")
        {
	       	Destroy(gameObject);
        }
//		Destroy(gameObject);
	}
}
