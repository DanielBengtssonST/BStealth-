using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//'Core' script handling all movement:
//- Manual/Controlled movement
//- Grounded & Gravity
//- Knockback forces
[RequireComponent(typeof(Rigidbody))]

public class MovementCore : MonoBehaviour {

	Rigidbody rig;

	public float curXVelocity, curYVelocity, curZVelocity;

	float knockbackDuration = 0.1f;
	float maxKnockbackForce = 500;

	[SerializeField] float knockbackMultiplier;

	public Vector3 knockback;
	Vector3 refVelocity;

	public bool grounded;

	float gravity = 26;			//<--Change to a universal value assigned by 'PlayManager'
	static float maxFallVelocity = 320;

	public float gravityMultiplier;

	// For initialization
	void Start () {

		rig = GetComponent<Rigidbody> ();
	}

	//Executes movement
	void FixedUpdate(){

		rig.velocity = (new Vector3 (
		/*  X  */	curXVelocity / Mathf.Max(Mathf.Abs(knockback.x)/20,1),
		/*  Y  */	curYVelocity,
		/*  Z  */	curZVelocity / Mathf.Max(Mathf.Abs(knockback.z)/20,1)) 
		/* All */	+ knockback) * 10 * Time.deltaTime;
	}
	//Manages external forces
	void Update () {

		//If airborn, a downward force is applied.
		if(!grounded){

			curYVelocity = Mathf.Max(curYVelocity -= gravity * 10 * gravityMultiplier * Time.deltaTime, -maxFallVelocity * gravityMultiplier);
		}
		//If a knockback force is active, it decays over a duration
		if (knockback != Vector3.zero) {

			knockback = Vector3.SmoothDamp (knockback, Vector3.zero, ref refVelocity, knockbackDuration ,maxKnockbackForce/1.75f);
		}
	}
	// Knockback management

	///Adds '_knockbackForce' to current active knockback.
	public void ApplyKnockbackForce(Vector3 _knockbackForce, bool _friendly){

		float _knockbackMultiplier = knockbackMultiplier;
		if (_friendly) {
			_knockbackMultiplier = 1;
		}
		knockback = new Vector3 (
			/* X */		Mathf.Clamp (knockback.x += _knockbackForce.x * _knockbackMultiplier, -maxKnockbackForce, maxKnockbackForce), 
			/* Y */		Mathf.Clamp (knockback.y += _knockbackForce.y * _knockbackMultiplier, -maxKnockbackForce, maxKnockbackForce),
			/* Z */		Mathf.Clamp (knockback.z += _knockbackForce.z * _knockbackMultiplier, -maxKnockbackForce, maxKnockbackForce)
			/*All*/		);
	}
	///Adds '_knockbackForce' to current active knockback.
	///_axis represents X[0], Y[1] & Z[2].
	public void ApplyKnockbackForce(float _knockbackForce, int _axis, bool _friendly){

		Vector3 _knockback = Vector3.zero;  
		_knockback [_axis] = _knockbackForce;
		ApplyKnockbackForce(_knockback,_friendly);
	}
	/// Set knockback multiplier value 
	public void SetKnockbackMultiplier(float _knockbackMultiplier){

		knockbackMultiplier = Mathf.Max (_knockbackMultiplier, 0);
	}

	//Bounce effect if colliding with wall with knockback force
	void OnCollisionEnter(Collision other){

		if (other.gameObject.CompareTag ("Wall")) {

			knockback = (knockback * -0.4f);
		}
	}
}