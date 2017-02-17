using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollision : MonoBehaviour {

	void OnCollisionEnter(Collision other){
		if (other.gameObject.CompareTag ("Player")) {
			other.gameObject.GetComponent<CharacterMovement> ().onFloor = true;
		}
	}

	void OnCollisionExit(Collision other){
		if (other.gameObject.CompareTag ("Player")) {
			other.gameObject.GetComponent<CharacterMovement> ().onFloor = false;
		}
	}

}
