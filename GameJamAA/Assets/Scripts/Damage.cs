﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Damage : MonoBehaviour {

	[SerializeField] int maxHealth;
	float deathExplosionForce = 20f;
	float deathExplosionRadius = 20f;
	[SerializeField]
	GameObject sombrero;
	int health;
	public static float healthRunaway;

	void Start () {
		health = maxHealth;
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.CompareTag ("Bala")) {
			if (gameObject.CompareTag ("Player")) {
				DamagePlayer ();
			} else {
					Color cor = sombrero.transform.GetComponent<Renderer> ().material.color;
					cor.r += .25f;
				if (--health == 0) {
					Die ();
				}
			}								
		}
	}

	//[ContextMenu("DamagePlayer!")]
	void DamagePlayer(){
		health--;
		UIManager.instance.HealthSpent (health);
		if (health == 0) {
			GameManager.instance.Defeat ();
			Die ();
		}
	}


	//[ContextMenu("Die")]
	void Die(){

		for (int i = transform.childCount - 1; i >= 0 ; i--) {
			KillMe (transform.GetChild (i));
		}

		Destroy (gameObject);

		/*for (int i = 0; i < transform.childCount; i++) {
			Rigidbody rigid = transform.GetChild (i).gameObject.AddComponent<Rigidbody> ();
			rigid.AddExplosionForce (deathExplosionForce, transform.position, deathExplosionRadius);
		}

		transform.DetachChildren ();*/
	}

	public void RefillHealth(){
		UIManager.instance.RefillHealth ();
		health = maxHealth;
	}

	void KillMe(Transform item){
		if (item.childCount != 0) {
			for (int j = item.childCount - 1; j>= 0 ; j--) {
				KillMe (item.GetChild (j));
			}
		}
		if (item.GetComponent<MeshRenderer> () == null && item.GetComponent<Camera>()==null) {
			Destroy (item.gameObject);
		} else {
			item.SetParent (null);
			Rigidbody rigid = item.gameObject.AddComponent<Rigidbody> ();
			rigid.AddExplosionForce (deathExplosionForce, transform.position, deathExplosionRadius);
			BoxCollider boxCollider = item.gameObject.GetComponent<BoxCollider> ();
			if (boxCollider == null) {
				item.gameObject.AddComponent<BoxCollider> ();
			}

			item.gameObject.tag = "Floor";
		}

	}

	void Update()
	{
		healthRunaway = health;
	}

}
