using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {


	private Rigidbody rb;
	public float speed;

	private int count;
	public Text countText;
	public Text winText;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCount ();
		winText.text = "";
	}

	void FixedUpdate()
	{

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement*speed);

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("PickUp")) 
		{
			other.gameObject.SetActive (false);
			count++;
			SetCount ();
		}
	}

	void SetCount()
	{
		countText.text = "Count : " + count.ToString ();
		if (count >= 8)
			winText.text = "Ai castigat, ba!";
	}

		
}
