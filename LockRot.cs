using UnityEngine;
using System.Collections;

public class LockRot : MonoBehaviour {

	float lockPos = 0;


	void Update()
	{
		transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 90, lockPos);
	}
}