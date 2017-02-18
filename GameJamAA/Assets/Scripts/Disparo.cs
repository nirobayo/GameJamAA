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

	void Start()
	{
		//BLOQUEAMOS EL RATON AQUI
		//Cursor.lockState = CursorLockMode.Locked;

		GameObject _bala = Instantiate (bala, pistola.transform.position, pistola.transform.rotation);
		cargador.Add (_bala);
		cargador [0].SetActive (false);
		_municion = tamanyoTamborRevolver;
		numeroTambores = tamboresMaximos;
	}

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Mouse0)) 
		{
			if (_municion > 0) 
			{
				Disparando ();
			}

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
				_municion--;
				UIManager.instance.AmmoSpent (_municion);
				return _balas;
			}
		}

		GameObject nuevaBala = NuevaBala ();
		nuevaBala.SetActive (true);
		_municion--;
		UIManager.instance.AmmoSpent (_municion);
		return nuevaBala;

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
