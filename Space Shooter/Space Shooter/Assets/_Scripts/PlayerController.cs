
using UnityEngine;
using System.Collections;

[System.Serializable]
public class Granita
{
	public float xMin, xMax, zMin, zMax;

}

public class PlayerController : MonoBehaviour 
{
	public float speed;
	public float tilt;
	public Granita granita;

	public GameObject shot;	
	public Transform shotSpawn;

	public float fireRate;
	private float nextTime = 0.0f;

	void Update()
	{
		if (Input.GetButton ("Fire1") && Time.time > nextTime) 
		{
			nextTime = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			AudioSource sunet = GetComponent<AudioSource> ();
			sunet.Play();
		}
	}


	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		Rigidbody rb = GetComponent<Rigidbody> ();

		rb.velocity = movement * speed;
		rb.position = new Vector3 (
			Mathf.Clamp(rb.position.x,granita.xMin,granita.xMax),
			0.0f,
			Mathf.Clamp(rb.position.z,granita.zMin,granita.zMax)
		);

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);

	}


		
}
