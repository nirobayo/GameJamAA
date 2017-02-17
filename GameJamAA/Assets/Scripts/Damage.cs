using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Damage : MonoBehaviour {

	[SerializeField] float maxHealth;
	float health;

	void Start () {
		health = maxHealth;
	}
	/*
	void OnCollisionEnter(Collision other){
		if (other.gameObject.CompareTag ("Bala")) {
			if (--health == 0) {
				Die ();
			}
		}
	}*/

	void Die(){
		Debug.Log("ME MUERO AAAAA");

		//TODO separar las piezas del objeto haciendo que de todas el parent sea null
	}

}
