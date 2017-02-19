using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminarCobardes : MonoBehaviour {


	Damage damage;

	void OnTriggerEnter(Collider malditoCobarde)
	{
		if (malditoCobarde.CompareTag ("Enemy")) 
		{
			damage = malditoCobarde.GetComponent<Damage> ();
			damage.Die();
		}
	}
}
