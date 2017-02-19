using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		} else if (Input.anyKey) {
			SceneManager.LoadScene ("Credits");
		}
	}
}
