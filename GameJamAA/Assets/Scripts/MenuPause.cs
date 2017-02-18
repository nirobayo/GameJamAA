using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour {

	[SerializeField]
	GameObject CanvasPause;

	bool pause;

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape))
			pause = !pause;

		if (pause)
			PauseOn();
		else
			PauseOff();


	}

	public void PauseOn()
	{
		CanvasPause.SetActive (true);
		Time.timeScale = 0;
	}

	public void PauseOff()
	{
		CanvasPause.SetActive (false);
		Time.timeScale = 1;
	}
}
