using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait = 1.0f;
	public float waveWait = 2.0f;
	public Text scoreText;
	public Text gameOverText;
	public Text restartText;

	private bool restart;
	private bool gameOver;
	private int score;
	private Vector3 spawnPosition = Vector3.zero;
	private Quaternion spawnRotation;

	public void AddScore (int val){
		score += val;
		UpdateScore();
	}

	public void GameOver (){
		gameOver = true;
		gameOverText.text = "游戏结束";
	}

	void Start (){
		score = 0;
		gameOver = false;
		restart = false;
		gameOverText.text = "";
		restartText.text = "";
		UpdateScore();
		StartCoroutine(SpawnWaves());
	}

	void Update (){
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				SceneManager.LoadScene(0);
			}
		}
	}

	IEnumerator SpawnWaves (){
		yield return new WaitForSecondsRealtime (startWait);
		while (true) {
			if (gameOver) {
				restartText.text = "按【R】键重新开始";
				restart = true;
				break;
			}

			for (int i = 0; i < hazardCount; ++i) {
				spawnPosition.x = Random.Range (-spawnValues.x, spawnValues.x);
				spawnPosition.z = spawnValues.z;
				spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSecondsRealtime (spawnWait);
			}
			yield return new WaitForSecondsRealtime (waveWait);
		}
	}

	void UpdateScore(){
		scoreText.text = "得分：" + score.ToString();
	}
}
