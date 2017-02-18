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
	bool detectado;
	[SerializeField]
	GameObject bala;
	[SerializeField]
	GameObject pistola;
	public static GameObject pistolaEnemigo;


	void Start()
	{
		navMesh = GetComponent<NavMeshAgent> ();
		Siguiente ();
		anim = GetComponent<Animator> ();
		pistolaEnemigo = pistola;
	}

	void Update () 
	{		
		
		if (Damage.healthRunaway <= 2) 
		{
			Huyendo ();
		}
		else 
		{
			if (navMesh.remainingDistance < 0.25)
				Siguiente ();	
			if (navMesh.remainingDistance > 5 && detectado) {				
				Corriendo ();
			} else if (navMesh.remainingDistance < 5 && detectado) {
				DisparoParado ();
			} 
		}
	}
		
	void Siguiente()
	{
		if (patrulla.Length == 0)
			return;
		navMesh.SetDestination (patrulla[Random.Range(0,patrulla.Length)].position);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Player")) 
		{
		 detectado = true;		 
		}
	}

	void DisparoParado()
	{
		if (anim.GetFloat ("Estados") != 2 ) {
			anim.SetFloat ("Estados", 2);	
		}		
		navMesh.speed = 0;
		transform.LookAt (GameObject.FindWithTag ("Player").transform);	
		navMesh.SetDestination (GameObject.FindWithTag ("Player").transform.position);
		Disparo ();
	}

    void Corriendo()
	 {	
		if (anim.GetFloat ("Estados") != 1 ) {
			anim.SetFloat ("Estados", 1);	
		}	
		transform.LookAt (GameObject.FindWithTag ("Player").transform);	
		navMesh.speed = 3;
		navMesh.SetDestination (GameObject.FindWithTag ("Player").transform.position);

	}

	[ContextMenu ("Huye")]
	void Huyendo()
	{
		if (anim.GetFloat ("Estados") != 5 ) {
			anim.SetFloat ("Estados", 5);	
		}
		//transform.LookAt (GameObject.FindWithTag ("Player").transform);	
		navMesh.speed = 3;
		navMesh.SetDestination (new Vector3(transform.position.x,transform.position.y,-transform.localPosition.z * -2));
		
	}

	void Disparo()
	{
		Instantiate (bala, pistola.transform.position, pistola.transform.rotation);
	}
}
