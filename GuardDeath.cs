using UnityEngine;
using System.Collections;

public class GuardDeath : MonoBehaviour {

	private RagdollHelper ragdoll;

	// Use this for initialization
	void Start () {
		ragdoll = GetComponentInParent<RagdollHelper> ();
	}

	// On collision
	void OnCollisionEnter(Collision collision)
	{
		if (transform.root != collision.transform.root) {
			if (!ragdoll.getKinematic()) {
				ragdoll.Kill (true);
			}
		}
	}
}
