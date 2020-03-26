using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineWave : MonoBehaviour {

	public GameObject player;
	Rigidbody rb;

	float displacement;

	void Start () {
		rb = GetComponent <Rigidbody>();
	}


	void Update () {

		displacement = 0.1f * Mathf.Sin (Time.time) + 2f;
		rb.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + displacement  ,player.transform.position.z);

		transform.Rotate (new Vector3 (15, 30, 45)/10 * Time.deltaTime);
	}
}
