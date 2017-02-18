using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	List<GameObject> enemies;

	// Use this for initialization
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
