using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public static UIManager instance;

	[SerializeField] GameObject currentAmmo;
	[SerializeField] GameObject healthBar;
	[SerializeField] GameObject magazineCount;

	List<Image> bullets;
	List<Image> health;
	List<Image> magazines;

	void Awake(){

		if (instance != null) {
			Destroy (this);
			return;
		} else {
			instance = this;
		}

		bullets = new List<Image> ();
		for (int i = 0; i < currentAmmo.transform.childCount; i++) {
			bullets.Add (currentAmmo.transform.GetChild (i).GetComponent<Image>());
		}
		health = new List<Image> ();
		for (int i = 0; i < healthBar.transform.childCount; i++) {
			health.Add (healthBar.transform.GetChild (i).GetComponent<Image>());
		}
		magazines = new List<Image> ();
		for (int i = 0; i < magazineCount.transform.childCount; i++) {
			magazines.Add (magazineCount.transform.GetChild (i).GetComponent<Image>());
		}
	}

	public void HealthSpent(int newHealth){
		health[newHealth].gameObject.SetActive(false);
	}

	public void MagazineSpent(int newMagazineCount){
		magazines[newMagazineCount].gameObject.SetActive(false);
	}

	public void AmmoSpent(int ammoCount){
		//aqui en realidad solo debemos quitar una bala
		//la bala a quitar es ammoCount+1!
		bullets[ammoCount].gameObject.SetActive(false);
	}

	public void RefillHealth(){
		foreach (Image whiskey in health) {
			whiskey.gameObject.SetActive (true);
		}
	}

	public void RefillMagazines(){
		foreach (Image magazine in magazines) {
			magazine.gameObject.SetActive (true);
		}
	}

	public void RefillBullets(){
		foreach (Image bullet in bullets) {
			bullet.gameObject.SetActive (true);
		}
	}
}
