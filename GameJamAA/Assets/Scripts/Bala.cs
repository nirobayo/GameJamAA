using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {

	[SerializeField]
	float velocidad = 10f;
	[SerializeField]
	GameObject pistola;

	void OnEnable () 
	{
		pistola = GameObject.Find("Pistola");
		transform.position = GameObject.Find("Pistola").transform.position;
		transform.GetComponent<Rigidbody> ().WakeUp ();
		transform.GetComponent<Rigidbody> ().isKinematic = false;
		transform.GetComponent<Rigidbody>().AddForce(GameObject.Find("Pistola").transform.forward  * velocidad ,ForceMode.Impulse);
		StartCoroutine ("Desactivacion");
	}

	void OnDisable()
	{
		transform.GetComponent<Rigidbody> ().Sleep ();
		transform.GetComponent<Rigidbody> ().isKinematic = true;
	}

	void OnCollisionEnter(Collision hit)
	{		
		gameObject.SetActive (false);
		transform.position = GameObject.Find("Pistola").transform.position;
	}


	IEnumerator Desactivacion()
	{
		yield return new WaitForSeconds (3);
		gameObject.SetActive (false);
		transform.position = GameObject.Find("Pistola").transform.position;
	}


}
