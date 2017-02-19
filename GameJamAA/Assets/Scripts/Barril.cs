using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Barril : MonoBehaviour {

	[SerializeField]
	GameObject explosion;
	[SerializeField]
	AudioClip explosionSound;


	void OnCollisionEnter(Collision hit)
	{
		if (hit.collider.CompareTag ("Bala")) {
			SoundManager.instance.PlaySound (explosionSound);
			GetComponent<Rigidbody> ().isKinematic = false;
			GetComponent<Rigidbody> ().AddExplosionForce (1000, transform.position, 10);
			explosion.SetActive (true);
			explosion.GetComponent<SphereCollider> ().enabled = true;
			explosion.GetComponent<SphereCollider> ().radius = 6;
		}
	}
}
