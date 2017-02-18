using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollisionChecker : MonoBehaviour {

	void OnCollisionEnter(Collision other){
		Debug.Log ("Collision");
		if (!other.gameObject.CompareTag ("Floor") && !other.gameObject.CompareTag ("Player")) {
			transform.GetChild (0).GetComponent<HealthBox> ().RespawnHealth ();
		}
	}
}
