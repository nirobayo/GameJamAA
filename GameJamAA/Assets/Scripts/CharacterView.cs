using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterView : MonoBehaviour {
	
	[SerializeField] float lookSpeed;

	Transform mainCamera;
	Vector3 angle = new Vector3();
	void Awake(){
		mainCamera = Camera.main.transform;
	}

	void Update () {
		float horizontal = Input.GetAxis ("Mouse X");
		float vertical = Input.GetAxis ("Mouse Y");

		angle.x += -vertical * lookSpeed;
		angle.y += horizontal * lookSpeed;

		if (angle.x < 300f && angle.x > 180f) {
			angle.x = 300f;

		} else if (angle.x > 60f && angle.x < 180f) {
			angle.x = 60f;
		}

		//transform.Rotate (0f,horizontal * lookSpeed,0f);
		//mainCamera.Rotate (, 0f, 0f);


		//transform.Rotate (-vertical * lookSpeed,horizontal * lookSpeed,0f);
		//Vector3 angle = mainCamera.localEulerAngles;


		/*if (angle.x < 300f && angle.x > 180f) {
			angle = new Vector3 (300f, 0f, 0f);

		} else if (angle.x > 60f && angle.x < 180f) {
			angle = new Vector3 (60f, 0f, 0f);
		}
		mainCamera.localEulerAngles = angle;
		*/

	

		transform.rotation = Quaternion.Euler(angle.x, angle.y, 0f);


	}
}
