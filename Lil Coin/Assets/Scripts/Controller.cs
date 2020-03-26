using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

	public Text player1;
	public Text player2;

	private AudioSource aud;
	public AudioClip[] audioClips;
	private int bani1;
	private int bani2;

	public Coin coin;

	private int dif = 50;

	void Afis()
	{
		player1.text = "$"	+ bani1.ToString () ;
		player2.text = "$"	+ bani2.ToString () ;
	}

	// Use this for initialization
	void Start () 
	{
		bani1 = bani2 = 1000;
		Afis ();
		aud = GetComponent<AudioSource> ();
	}
	

	void Update () 
	{
		
	}

	public void UpdateCastig()
	{
		switch (coin.castig) 
		{
		case 0:
			{
				bani1 += dif;
				bani2 -= dif;
				Afis ();
				aud.clip = audioClips[0];
				aud.Play ();
				break;
			}
		case 1:
			{
				bani2 += dif;
				bani1 -= dif;
				Afis ();
				aud.clip = audioClips[1];
				aud.Play ();
				break;
			}
		case 2:
			{
				Afis ();
				break;
			}
		}
	}

}
