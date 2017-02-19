using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour {

	[SerializeField]
	GameObject CanvasPause;
	[SerializeField]
	AudioMixerGroup audi;
	bool pause;
	[SerializeField]
	GameObject player;

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			pause = !pause;

		}
		if (pause) {
			PauseOn ();
			Cursor.visible = true;
		} else {
			PauseOff ();
			Cursor.visible = false;
		}
	}

	public void PauseOn()
	{
		CanvasPause.SetActive (true);
		Time.timeScale = 0;
		audi.audioMixer.SetFloat ("Volume",-80);
		player.GetComponent<CharacterView> ().enabled = false;
		player.GetComponent<Disparo> ().enabled = false;
	}

	public void PauseOff()
	{
		CanvasPause.SetActive (false);
		Time.timeScale = 1;
		audi.audioMixer.SetFloat ("Volume", -20);
		player.GetComponent<CharacterView> ().enabled = true;
		player.GetComponent<Disparo> ().enabled = true;
		pause = false;
	}

	public void MenuPrincipal()
	{
		SceneManager.LoadScene (0);
	}

	public void Salir()
	{
		Application.Quit ();
		Debug.Log ("Has Salido");
	}
}
