using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterView : MonoBehaviour {
	
	[SerializeField] float lookSpeed;

	void Update () {
		float horizontal = Input.GetAxis ("Mouse X");
		float vertical = Input.GetAxis ("Mouse Y");

		transform.Rotate (0f,horizontal * lookSpeed,0f);
		Camera.main.transform.Rotate (-vertical * lookSpeed, 0f, 0f);
	}
}
