using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Barril : MonoBehaviour {

	[SerializeField]
	GameObject explosion;

	void OnCollisionEnter(Collision hit)
	{
		if (hit.collider.CompareTag ("Bala")) {
			GetComponent<Rigidbody> ().isKinematic = false;
			GetComponent<Rigidbody> ().AddExplosionForce (1000, transform.position, 10);
			explosion.SetActive (true);
			explosion.GetComponent<SphereCollider> ().enabled = true;
			explosion.GetComponent<SphereCollider> ().radius = 6;
			StartCoroutine ("Boom");
		}
	}

	IEnumerator Boom()
	{
		yield return new WaitForSeconds (2);
		Destroy (gameObject);
	}
}
