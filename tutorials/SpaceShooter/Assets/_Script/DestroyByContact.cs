using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public GameController gameController;
	public int scoreValue = 10;

	void Start (){
		GameObject go = GameObject.FindWithTag ("GameController");
		gameController = go.GetComponent<GameController>();
	}

	void OnTriggerEnter (Collider other){
		if (other.tag != "Boundary") {
			Instantiate(explosion, transform.position, transform.rotation);
			if (other.tag == "Player") {
				Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
				gameController.GameOver();
			}
			Destroy (other.gameObject);
			Destroy (gameObject);
			gameController.AddScore(scoreValue);
		}
	}
}
