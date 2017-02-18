using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA : MonoBehaviour {

	NavMeshAgent navMesh;

	[SerializeField]
	Transform[] patrulla;
	int puntoRuta;
	void Start()
	{
		navMesh = GetComponent<NavMeshAgent> ();
		Siguiente ();
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
		navMesh.SetDestination (patrulla[puntoRuta].position);
		puntoRuta = (puntoRuta + 1) % patrulla.Length;
	}
}
