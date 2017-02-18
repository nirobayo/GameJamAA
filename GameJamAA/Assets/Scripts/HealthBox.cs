using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class HealthBox : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			other.gameObject.GetComponent<Damage> ().RefillHealth ();
			RespawnHealth ();
		}
	}

	public void RespawnHealth(){
		float xPosition = Random.value * (GameManager.instance.positiveLimitX - GameManager.instance.negativeLimitX) + GameManager.instance.negativeLimitX;
		float zPosition = Random.value * (GameManager.instance.positiveLimitZ - GameManager.instance.negativeLimitZ) + GameManager.instance.negativeLimitZ;

		transform.position = new Vector3 (xPosition, transform.position.y, zPosition);
	}
}
