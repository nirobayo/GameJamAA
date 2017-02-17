using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {

	[SerializeField]
	float velocidad = 10f;

	void OnEnable () 
	{
		transform.GetComponent<Rigidbody> ().WakeUp ();
		transform.GetComponent<Rigidbody> ().isKinematic = false;
		transform.GetComponent<Rigidbody>().AddForce(Vector3.forward * velocidad ,ForceMode.Impulse);
	}

	void OnDisable()
	{
		transform.GetComponent<Rigidbody> ().Sleep ();
		transform.GetComponent<Rigidbody> ().isKinematic = true;
	}

	void OnCollisionEnter(Collision hit)
	{
		gameObject.SetActive (false);
		transform.position = transform.parent.position;
	}


}
