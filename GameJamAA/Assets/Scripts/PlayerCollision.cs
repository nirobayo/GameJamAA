using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	void OnCollisionEnter(Collision other){
		if (other.gameObject.CompareTag ("Floor")) {
			gameObject.GetComponent<CharacterMovement> ().onFloor = true;
		}
	}

	void OnCollisionExit(Collision other){
		if (other.gameObject.CompareTag ("Floor")) {
			gameObject.GetComponent<CharacterMovement> ().onFloor = false;
		}
	}

}
