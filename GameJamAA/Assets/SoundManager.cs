using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static SoundManager instance;
	[SerializeField] Object audioSourcePrefab;
	public AudioClip slap;
	AudioClip latestSound;

	void Awake(){
		if (instance == null) {
			instance = this;
		} else {
			Destroy (this);
		}
	}

	public void PlaySound(AudioClip sound){
		latestSound = sound;
		StartCoroutine ("PlaySound2");
	}

	IEnumerator PlaySound2(){
		GameObject source = Instantiate (audioSourcePrefab, transform) as GameObject;
		AudioSource src = source.GetComponent<AudioSource> ();
		src.clip = latestSound;
		src.Play ();
		float time = 0f;
		while (src.clip.length > time) {
			time += Time.deltaTime;
			yield return null;
		}
		Destroy (source);

	}

}
