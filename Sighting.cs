using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Sighting : MonoBehaviour
{

	public AudioClip Nope;
	public AudioClip Bells;

	private GameObject player;
	private AudioSource audioPlayer;
	private AudioSource bellPlayer;

	private bool caught = false;
	private bool rang = false;
//	private List<Transform> bodies = new List<Transform>();

	private GameObject[] guards;

	// Use this for initialization
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		audioPlayer = GetComponent<AudioSource>();
		bellPlayer = GetComponentInChildren<AudioSource>();
		guards = GameObject.FindGameObjectsWithTag("Guard");
	}

	public void PlayerSighted()
	{
		if (!caught) {
			caught = true;
			audioPlayer.Stop();
			audioPlayer.clip = Nope;
			audioPlayer.PlayOneShot(Nope, 0.5f);
			player.SendMessage("SetMoving", false);
		}
	}

	public void PlayerKilled()
	{
		if (!caught) {
			caught = true;
			player.SendMessage("SetMoving", false);
			if (SceneManager.GetActiveScene().name == "Level1") {
				SceneManager.LoadScene("TryAgain1");
			} else if (SceneManager.GetActiveScene().name == "Level2") {
				SceneManager.LoadScene("TryAgain2");
			}
		}
	}

	public void RingBells()
	{
		if (!rang) {
			rang = true;
			bellPlayer.Stop();
			bellPlayer.clip = Bells;
			bellPlayer.PlayOneShot(Bells, 0.7f);
			foreach (GameObject guard in guards) {
				guard.SendMessage("Warning");
			}
		}
	}
}
