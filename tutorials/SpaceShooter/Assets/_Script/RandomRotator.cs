using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

	public float tumble = 10.0f;

	void Start() {
		Rigidbody rb = GetComponent<Rigidbody>();
		rb.angularVelocity = Random.insideUnitSphere * tumble;
	}
}
