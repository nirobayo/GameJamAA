using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA : MonoBehaviour {

	NavMeshAgent navMesh;

	[SerializeField]
	Transform[] patrulla;
	[SerializeField]
	GameObject[] bala;
	[SerializeField]
	GameObject pistola;


	public static GameObject pistolaEnemigo;
	float retardo;
	int municion=1;
	bool detectado;
	bool buscando;
	Animator anim;
	int puntoRuta;
	Ray rayo;
	RaycastHit hit;
	[SerializeField]
	GameObject sombrero;
	GameObject player;


	void Start()
	{
		player = GameObject.FindWithTag ("Player");
		navMesh = GetComponent<NavMeshAgent> ();
		Siguiente ();
		anim = GetComponent<Animator> ();
	}

	void Update () 
	{		
		pistolaEnemigo = pistola;
		if (Damage.healthRunaway <= 2) 
		{
			Huyendo ();
		}
		else 
		{
			if (!buscando) {
				if (navMesh.remainingDistance < 0.25)
					Siguiente ();	
				if (navMesh.remainingDistance > 5 && detectado) {				
					Corriendo ();
				} else if (navMesh.remainingDistance < 5 && detectado) {
					DisparoParado ();
				} 
			}
			else 
			{
				Busqueda ();			
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{		
		if (other.CompareTag ("Ruido")) 
		{
			if (!detectado) {
				buscando = true;
				navMesh.SetDestination (other.transform.position);
			}
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.CompareTag ("Player")) 
		{
			rayo.origin = sombrero.transform.position;
			rayo.direction = player.transform.position - sombrero.transform.position;
			if (Physics.Raycast (rayo, out hit)&&hit.collider.CompareTag("Player")) 
			{
				detectado = true;	
				buscando = false;
			}
		}
	}
				
	#region Acciones

	void Siguiente()
	{
		buscando = false;
		if (patrulla.Length == 0)
			return;
		navMesh.SetDestination (patrulla[Random.Range(0,patrulla.Length)].position);
		navMesh.speed = 1;
	}

	void DisparoParado()
	{
		buscando = false;
		navMesh.speed = 0;
		transform.LookAt (player.transform);	
		navMesh.SetDestination (player.transform.position);
		Disparo ();
	}

    void Corriendo()
	 {	
		buscando = false;
		if (anim.GetFloat ("Estados") != 1 ) {
			anim.SetFloat ("Estados", 1);	
		}	
		transform.LookAt (player.transform);	
		navMesh.speed = 3;
		navMesh.SetDestination (player.transform.position);

	}
	[ContextMenu("Huida")]
	void Huyendo()
	{
		buscando = false;
		if (anim.GetFloat ("Estados") != 5 ) {
			anim.SetFloat ("Estados", 5);	
		}
		//transform.LookAt (GameObject.FindWithTag ("Player").transform);	
		navMesh.speed = 3;
		navMesh.SetDestination (new Vector3(transform.position.x,transform.position.y,-transform.localPosition.z * -2));
	}

	void Disparo()
	{
		buscando = false;
		retardo += Time.deltaTime;
		if (retardo > 0 && retardo < 0.3f)
		{
			if (municion == 1) {
				if (anim.GetFloat ("Estados") != 2) {
					anim.SetFloat ("Estados", 2);	
				}
				Instantiate (bala [0], pistola.transform.position, pistola.transform.rotation);
				municion--;
			}
		} else if (retardo >= 1) {
			retardo = 0;
			municion = 1;
		}		
	}

	void Busqueda()
	{
		if (anim.GetFloat ("Estados") != 3) {
			anim.SetFloat ("Estados", 3);	
			navMesh.speed = 3;
		}

		if (navMesh.remainingDistance < 0.25f) 
		{
			if (anim.GetFloat ("Estados") != 4) {
				anim.SetFloat ("Estados", 4);	
			}
			navMesh.speed = 0;
			StartCoroutine ("TerminaBusqueda");
		}
	}

	#endregion

	IEnumerator TerminaBusqueda()
	{
		yield return new WaitForSeconds (3);
		Siguiente();
		if (anim.GetFloat ("Estados") != 0) {
			anim.SetFloat ("Estados", 0);	
		}
	}
}
