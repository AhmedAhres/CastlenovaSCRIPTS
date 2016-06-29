using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WaterCollision : MonoBehaviour {

	private GameObject controller;

	// Use this for initialization
	void Start () {
		controller = GameObject.FindGameObjectWithTag("GameController");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider target) {
		if( target.gameObject.tag.Equals("Water")){
			controller.SendMessage("PlayerKilled");
		} else if (target.gameObject.tag.Equals("Door")) {
			if (SceneManager.GetActiveScene().name == "Level1") {
				SceneManager.LoadScene("Success1");
			} else if (SceneManager.GetActiveScene().name == "Level2") {
				SceneManager.LoadScene("Success2");
			}
		}
	}
}
