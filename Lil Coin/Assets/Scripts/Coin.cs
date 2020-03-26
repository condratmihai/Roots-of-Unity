using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	Animator anim;
	float rand;
	public Sprite[] yellowCoins;
	public Sprite[] purpleCoins;
	public Sprite[] drawCoins;
	Sprite curentSprite;
	public Controller controller;

	SpriteRenderer spriteRenderer;

	public int castig;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		curentSprite = spriteRenderer.sprite;

	}

	public IEnumerator Flip()
	{
		anim.enabled = true;

		rand = Random.Range (1f, 3f);


		yield return new WaitForSeconds (rand);

		Sprite coinSprite;
		coinSprite = curentSprite;

		for (int i = 0; i <= 2; i++) 
		{
			if (coinSprite == yellowCoins [i])
				castig = 0;
			else if (coinSprite == purpleCoins [i])
				castig = 1;
			else if (i <= 1) {
				if (coinSprite == drawCoins [i])
					castig = 2;
			}
		
		}
		controller.UpdateCastig ();
		anim.enabled = false;

	}

	public void StartFlip()
	{
		StartCoroutine (Flip ());
	}
}
