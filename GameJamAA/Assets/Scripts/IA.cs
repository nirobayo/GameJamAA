using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA : MonoBehaviour {

	NavMeshAgent navMesh;

	[SerializeField]
	Transform[] patrulla;
	int puntoRuta;
	Animator anim;


	void Start()
	{
		navMesh = GetComponent<NavMeshAgent> ();
		Siguiente ();
		anim = GetComponent<Animator> ();
	}

	void Update () 
	{		
		if (navMesh.remainingDistance < 0.25)
			Siguiente ();			
	}
		
	void Siguiente()
	{
		if (patrulla.Length == 0)
			return;
		navMesh.SetDestination (patrulla[Random.Range(0,patrulla.Length)].position);
		//puntoRuta = (puntoRuta + 1) % patrulla.Length;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Player")) 
		{
			anim.SetTrigger ("CorreArma");
			navMesh.speed = 3;
			navMesh.SetDestination (other.transform.position);

			if (navMesh.remainingDistance < 3) 
			{
				navMesh.speed = 0;
				anim.SetTrigger ("DisparoParado");
			}
		}
	}
}
