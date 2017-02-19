using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {

	[SerializeField]
	float velocidad = 10f;
	[SerializeField]
	GameObject pistola;
	[SerializeField]
	bool Enemigo;

	void OnEnable () 
	{
		if (!Enemigo) {
			pistola = GameObject.Find ("Pistola2");
			transform.position = pistola.transform.position;
			transform.GetComponent<Rigidbody> ().WakeUp ();
			transform.GetComponent<Rigidbody> ().isKinematic = false;
			transform.GetComponent<Rigidbody> ().AddForce (pistola.transform.forward * velocidad, ForceMode.Impulse);
			StartCoroutine ("Desactivacion");
		} else {
			pistola = IA.pistolaEnemigo;
			transform.position = IA.pistolaEnemigo.transform.position;
			transform.LookAt (GameObject.FindWithTag ("Player").transform.position);
			transform.GetComponent<Rigidbody> ().WakeUp ();
			transform.GetComponent<Rigidbody> ().isKinematic = false;
			transform.GetComponent<Rigidbody> ().AddForce (transform.forward * velocidad, ForceMode.Impulse);
			StartCoroutine ("Desactivacion");
		}
	}

	void OnDisable()
	{
		transform.GetComponent<Rigidbody> ().Sleep ();
		transform.GetComponent<Rigidbody> ().isKinematic = true;
	}

	void OnCollisionEnter(Collision hit)
	{		
		gameObject.SetActive (false);

		if (!Enemigo) {
			transform.position = pistola.transform.position;
			transform.rotation = pistola.transform.rotation;
		} else {
			transform.position = IA.pistolaEnemigo.transform.position;
			transform.rotation = IA.pistolaEnemigo.transform.rotation;
		}
	}


	IEnumerator Desactivacion()
	{
		yield return new WaitForSeconds (3);
		gameObject.SetActive (false);

		if (!Enemigo) {
			transform.position = pistola.transform.position;
			transform.rotation = pistola.transform.rotation;
		} else {
			transform.position = IA.pistolaEnemigo.transform.position;
			transform.rotation = IA.pistolaEnemigo.transform.rotation;
		}
	}
}
