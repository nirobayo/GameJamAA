using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour {

	[SerializeField]
	GameObject bala;
	[SerializeField]
	List<GameObject> cargador = new List<GameObject>();
	[SerializeField]
	int tamanyoTamborRevolver;
	[SerializeField]
	GameObject pistola;
	[SerializeField]
	int tamboresMaximos;

	Ray rayo;
	RaycastHit hit;
	int _municion;
	int numeroTambores;

	float maxCooldown = .4f;
	float currCooldown;

	Animator anim{
		get{
			return GetComponent<Animator> ();
		}
	}

	void Start()
	{
		//BLOQUEAMOS EL RATON AQUI
		//Cursor.lockState = CursorLockMode.Locked;

		GameObject _bala = Instantiate (bala, pistola.transform.position, pistola.transform.rotation);
		cargador.Add (_bala);
		cargador [0].SetActive (false);
		_municion = tamanyoTamborRevolver;
		numeroTambores = tamboresMaximos;

		currCooldown = maxCooldown;
	}

	void Update () 
	{
		currCooldown -= Time.deltaTime;
		if (Input.GetKeyDown (KeyCode.Mouse0) && currCooldown <= 0f) 
		{
			currCooldown = maxCooldown;
			if(_municion>0)
			 Disparando ();
		}

		if (Input.GetButtonDown ("Fire2"))
		{
			Recargando ();
		}

		rayo = Camera.main.ScreenPointToRay (new Vector3 (Screen.width/2,Screen.height/2));
		Debug.DrawRay (rayo.origin, rayo.direction, Color.blue);

		if (Physics.Raycast (rayo, out hit)) 
		{
			pistola.transform.LookAt (hit.point);
		}

		#if UNITY_EDITOR
		if(Input.GetKeyDown(KeyCode.C))
		{
			bool mouse = false;
			mouse=!mouse;

			if(mouse)
				Cursor.lockState = CursorLockMode.Locked;
			else
			{
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible=true;
			}	
		}
		#endif
	}



	GameObject Disparando()
	{		
		foreach (GameObject _balas in cargador) 
		{
			if (!_balas.activeSelf) 
			{
				_balas.SetActive (true);
				ShootingParams ();
				return _balas;
			}
		}

		GameObject nuevaBala = NuevaBala ();
		nuevaBala.SetActive (true);
		ShootingParams ();
		return nuevaBala;

	}

	void ShootingParams(){
		_municion--;
		UIManager.instance.AmmoSpent (_municion);
		//GetComponent<Animator> ().SetFloat ("AnimParam", 2f); //dispara
		anim.SetTrigger("Shoot");
		if (_municion == 0) {
			anim.SetTrigger ("FuckYou");
			//StartCoroutine ("Insult");
		} /*else {
			StartCoroutine ("ReturnToAiming");
		}*/
	}

	IEnumerator Insult(){
		yield return new WaitForSeconds (1f);
		//GetComponent<Animator> ().SetFloat ("AnimParam", 1f); //insult
		anim.SetTrigger("FuckYou");
		//StartCoroutine ("ReturnToAiming");
	}

	IEnumerator ReturnToAiming(){
		yield return new WaitForSeconds (1f);
		//GetComponent<Animator> ().SetFloat ("AnimParam", 0f); //aim
	}

	GameObject NuevaBala()
	{
		GameObject _bala = Instantiate (bala, pistola.transform.position, pistola.transform.rotation);
		cargador.Add (_bala);
		return _bala;
	}

	void Recargando()
	{
		if (numeroTambores >= 1) {
			anim.SetTrigger ("Reload");
			_municion = tamanyoTamborRevolver;
			numeroTambores--;
			UIManager.instance.RefillBullets ();
			UIManager.instance.MagazineSpent (numeroTambores);
		}

	}

	public void RefillAmmo(){
		UIManager.instance.RefillMagazines ();
		numeroTambores = tamboresMaximos;
	}

}
