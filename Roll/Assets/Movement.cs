using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	Rigidbody rb;
	float h,v;

	void Start () {
		rb = GetComponent <Rigidbody>();
	}
	
	 
	void Update () {
		
		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");

		Vector3 pos = new Vector3 (h/5, 0, v/5);
		rb.transform.position += pos;

		//transform.Rotate(new Vector3 (0, 15,0) * Time.deltaTime);
	}
}
