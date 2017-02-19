using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuPause : MonoBehaviour {

	[SerializeField]
	GameObject CanvasPause;
	[SerializeField]
	AudioMixer audioM;
	bool pause;

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape))
			pause = !pause;

		if (pause) {
			PauseOn ();
			//audioM ("Master", -80);
			//audioM.audioMixer.SetFloat ("Pause", 0);
		} else {
			PauseOff ();
		}

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
