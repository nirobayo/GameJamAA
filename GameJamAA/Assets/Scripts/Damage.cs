using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Damage : MonoBehaviour {

	[SerializeField] float maxHealth;
	float deathExplosionForce = 200f;
	float deathExplosionRadius = 20f;

	float health;

	void Start () {
		health = maxHealth;
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.CompareTag ("Bala")) {
			if (--health == 0) {
				Die ();
			}
		}
	}


	[ContextMenu("Die")]
	void Die(){
		for (int i = 0; i < transform.childCount; i++) {
			Rigidbody rigid = transform.GetChild (i).gameObject.AddComponent<Rigidbody> ();
			rigid.AddExplosionForce (deathExplosionForce, transform.position, deathExplosionRadius);
		}

		transform.DetachChildren ();
		Destroy (gameObject);
	}

}
