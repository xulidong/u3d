﻿using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed = 5.0f;

	void Start () {
		Rigidbody rb = GetComponent<Rigidbody>();
		rb.velocity = transform.forward * speed;
	}
}
