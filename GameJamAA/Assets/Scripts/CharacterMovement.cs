using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour {

	[SerializeField] float moveSpeed;
	[SerializeField] float jumpSpeed;

	Rigidbody rigid{
		get{
			return GetComponent<Rigidbody> ();
		}
	}

	bool jump = false;
	int moveSide = 0;
	int moveFront = 0;

	public bool onFloor = false;

	void FixedUpdate (){
		if (jump && onFloor) {
			rigid.AddForce (Vector3.up * jumpSpeed, ForceMode.Impulse);
		}

		if (moveSide != 0) {
			float scaleParameter = 1f;
			if(!onFloor){
				scaleParameter = .1f;
			}
			rigid.AddForce (transform.right * moveSide * moveSpeed * scaleParameter, ForceMode.Impulse);
		}

		if (moveFront != 0) {
			float scaleParameter = 1f;
			if(!onFloor){
				scaleParameter = .1f;
			}
			Debug.Log ("Force: " + moveFront * moveSpeed * scaleParameter);

			rigid.AddForce (transform.forward * moveFront * moveSpeed * scaleParameter, ForceMode.Impulse);
		}
	}

	void Update () {
		if (Input.GetAxisRaw ("Jump") > 0) {
			jump = true;
		} else {
			jump = false;
		}

		float side = Input.GetAxisRaw ("Horizontal");
		if (side != 0) {
			moveSide = Mathf.FloorToInt(side);
		} else {
			moveSide = 0;
		}

		float front = Input.GetAxisRaw ("Vertical");
		if (front != 0) {
			moveFront = Mathf.FloorToInt(front);
		} else {
			moveFront = 0;
		}
	}
}
