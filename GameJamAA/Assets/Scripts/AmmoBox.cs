using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class AmmoBox : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			other.gameObject.GetComponent<Disparo> ().RefillAmmo ();
			Debug.Log ("Moar ammo");
		}
	}
}
