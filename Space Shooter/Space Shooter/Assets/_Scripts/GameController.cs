using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour 
{
	public GameObject[] hazards;
	public Vector3 spawnValues;

	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	private int score;

	private bool gameOver;
	private bool restart;

	void Start()
	{
		score = 0;
		UpdateScore ();	
		StartCoroutine (SpawnWaves ());
		gameOver = restart = false;
		restartText.text = "";
		gameOverText.text = "";

	}

	void Update()
	{
		if (restart) 
		{
			if(Input.GetKeyDown(KeyCode.R))
				{
				SceneManager.LoadScene (0);
				}
				
		}
	}


	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);

		while(true)
		{
			for(int i=0;i<hazardCount;i++)
			{

				GameObject hazard = hazards[Random.Range(0,hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x,spawnValues.x) ,spawnValues.y,spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
				if (gameOver)
					yield break;
			} 
			yield return new WaitForSeconds (waveWait);

			if (gameOver) {
				restartText.text = "Press 'R' to restart!";
				restart = true;
				break;
			}

		}
	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore()
	{
		scoreText.text = "Score:" + score;
	}

	public void GameOver()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}

}
