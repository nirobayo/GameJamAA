using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA : MonoBehaviour {

	NavMeshAgent navMesh;

	[SerializeField]
	Transform patrulla;

	void Start()
	{
		navMesh = GetComponent<NavMeshAgent> ();
	}

	void Update () 
	{
		
	}
		
}
