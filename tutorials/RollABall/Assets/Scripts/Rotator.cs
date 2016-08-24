using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	private Vector3 eulerAngles = new Vector3(15, 30, 45);

	void Update () {
		transform.Rotate(eulerAngles * Time.deltaTime);	
	}
}
