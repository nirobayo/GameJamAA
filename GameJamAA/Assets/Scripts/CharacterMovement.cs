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
			
			rigid.AddForce (Vector3.up * jumpSpeed, ForceMode.VelocityChange);
		}
		/*
		if (moveSide != 0) {
			float scaleParameter = 1f;
			if(!onFloor){
				scaleParameter = .1f;
			}
			transform.Translate (transform.right * moveSide * moveSpeed * scaleParameter);
			//rigid.AddForce (transform.right * moveSide * moveSpeed * scaleParameter, ForceMode.Impulse);
		}

		if (moveFront != 0) {
			float scaleParameter = 1f;
			if(!onFloor){
				scaleParameter = .1f;
			}

			//rigid.AddForce (transform.forward * moveFront * moveSpeed * scaleParameter, ForceMode.Impulse);
			transform.Translate (transform.forward * moveFront * moveSpeed * scaleParameter);
		}*/
	}

	void Update () {
		if (Input.GetAxisRaw ("Jump") > 0) {
			jump = true;
		} else {
			jump = false;
		}

		float front = Input.GetAxis ("Vertical");
		if (front != 0) {
			transform.Translate (0,0,front * moveSpeed * Time.deltaTime);
		}

		float side = Input.GetAxis ("Horizontal");
		if (side != 0) {
			transform.Translate (side * moveSpeed * Time.deltaTime,0,0);
		}

		/*float front = Input.GetAxis ("Vertical");
		if (front != 0) {
			moveFront = Mathf.FloorToInt(front);
		} else {
			moveFront = 0;
		}*/
	}
}
