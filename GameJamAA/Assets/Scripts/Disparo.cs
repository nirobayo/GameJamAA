﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour {

	[SerializeField]
	GameObject bala;
	[SerializeField]
	List<GameObject> cargador = new List<GameObject>();
	[SerializeField]
	int municion;
	[SerializeField]
	GameObject pistola;

	int _municion;
	void Start()
	{
		//Cursor.lockState = CursorLockMode.Locked;
		GameObject _bala = Instantiate (bala, pistola.transform.position, pistola.transform.rotation);
		cargador.Add (_bala);
		cargador [0].SetActive (false);
		_municion = municion;
	}

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Mouse0)) 
		{
			if(_municion>0)
			 Disparando ();
		}

		if (Input.GetButtonDown ("Fire2"))
		{
			Recargando ();
		}
	}

	GameObject Disparando()
	{		
		foreach (GameObject _balas in cargador) 
		{
			if (!_balas.activeSelf) 
			{
				_balas.SetActive (true);
				_municion--;
				return _balas;
			}
		}

		GameObject nuevaBala = NuevaBala ();
		nuevaBala.SetActive (true);
		_municion--;
        return NuevaBala ();

	}

	GameObject NuevaBala()
	{
		GameObject _bala = Instantiate (bala, pistola.transform.position, pistola.transform.rotation);
		cargador.Add (_bala);
		return _bala;
	}

	void Recargando()
	{
		_municion = municion;
	}

}
