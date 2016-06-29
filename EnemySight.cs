using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour
{
	public float fieldOfViewAngle = 80f;
	// Number of degrees, centred on forward, for the enemy see.
	private GameObject controller;

	private SphereCollider col;
	// Reference to the sphere collider trigger component.
	private GameObject player;
	// Reference to the player.

	void Awake()
	{
		// Setting up the references.
		col = GetComponent<SphereCollider>();
		player = GameObject.FindGameObjectWithTag("Player");
		controller = GameObject.FindGameObjectWithTag("GameController");
	}

	void OnTriggerStay(Collider other)
	{			
		if (gameObject.tag != "DeadGuard") {
			// If the player has entered the trigger sphere...
			if (other.gameObject == player || other.gameObject.tag == "DeadGuard") {

				// Create a vector from the enemy to the player and store the angle between it and forward.
				Vector3 direction = other.transform.position - transform.position;
				float angle = Vector3.Angle(direction, transform.forward);

				// If the angle between forward and where the player is, is less than half the angle of view...
				if (angle < fieldOfViewAngle * 0.5f) {
					RaycastHit hit;

					// ... and if a raycast towards the player hits something...
					if (Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, col.radius)) {
						// ... and if the raycast hits the player...
						if (hit.collider.gameObject == player) {
							// ... the player is in sight.
							controller.SendMessage("PlayerSighted");
							gameObject.GetComponent<EnemyPath>().SetSeen();
						} else if (hit.collider.gameObject.tag == "DeadGuard") {
							controller.SendMessage("RingBells");
						}
					}
				}
			}
		}
	}

	private void Warning()
	{
		col.radius = 10;
	}
}