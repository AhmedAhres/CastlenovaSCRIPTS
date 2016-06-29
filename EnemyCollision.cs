using UnityEngine;
using System.Collections;

public class EnemyCollision : MonoBehaviour
{
	private GameObject player;
	private GameObject controller;
	private BoxCollider box;
	private bool dragging = false;

	void Awake()
	{
		// Setting up the references.
		player = GameObject.FindGameObjectWithTag("Player");
		controller = GameObject.FindGameObjectWithTag("GameController");
		box = GetComponent<BoxCollider> ();
	}

	void Update()
	{
		if (dragging) {
			if (Input.GetMouseButton (0)) {
				MoveTowardsPlayer ();
			} else {
				// Save a variable
				dragging = false;
			}
		} else {
			if (gameObject.transform.parent.tag == "DeadGuard") {
				Transform body = transform.parent.Find ("hips").transform;
				box.center = body.localPosition;

				Vector3 diff = player.transform.position - body.position;
				if (Input.GetMouseButtonDown (0) && diff.magnitude < 2f) {
					// Set variable
					dragging = true;
				}
			}
		}
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player) {
			if (!(gameObject.transform.parent.tag == "DeadGuard")) {
				controller.SendMessage("PlayerSighted");
				GetComponentInParent<EnemyPath> ().SetSeen ();
			}
		}
	}

	// Move the guard towards the player
	void MoveTowardsPlayer()
	{
		Rigidbody body = player.GetComponent<Rigidbody>();
		float mag = body.velocity.magnitude;
		if (mag < 0.15f)
			mag = 0;
		
		Vector3 vec = player.transform.forward;
		vec.y = 0;
		transform.parent.position += vec * mag * Time.deltaTime;
	}
}