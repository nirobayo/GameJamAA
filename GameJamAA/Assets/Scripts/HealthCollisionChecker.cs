using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollisionChecker : MonoBehaviour {

	void OnCollisionEnter(Collision other){
		if (!other.gameObject.CompareTag ("Floor") && !other.gameObject.CompareTag ("Player") && !other.gameObject.CompareTag ("Bala")) {
			transform.GetChild (0).GetComponent<HealthBox> ().RespawnHealth ();
		}
	}
}
