using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	List<GameObject> enemies;

	[SerializeField] public float positiveLimitX;
	[SerializeField] public float negativeLimitX;
	[SerializeField] public float positiveLimitZ;
	[SerializeField] public float negativeLimitZ;

	void Awake(){
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
		}
	}

	void Start () {
		enemies = new List<GameObject> ();
		enemies.AddRange(GameObject.FindGameObjectsWithTag ("Enemy"));
	}

	public void RemoveEnemy(GameObject enemy){
		enemies.Remove (enemy);
		if (enemies.Count == 0) {
			Victory ();
		}
	}

	public void Defeat(){
		
	}

	void Victory(){

	}


}
