using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {


	[SerializeField]
	private Text scoreText;
	[SerializeField]
	private Text coinText;
	[SerializeField]
	private Text lifeText;

	[SerializeField]
	private Text finalScoreText;
	[SerializeField]
	private Text finalCoinText;

	[SerializeField]
	private GameObject readyButton;

	[SerializeField]
	private GameObject pausePanel;
	[SerializeField]
	private GameObject gameOverPanel;

	public static GameplayController instance;

	void Awake(){
		CreateInstance ();
	}

	void Start (){
		Time.timeScale = 0;
	}

	void CreateInstance(){
		if (instance == null) {
			instance = this;
		}
	}

	public void ShowGameOverPanel(int finalScore, int finalCoinScore){
		gameOverPanel.SetActive(true);
		finalScoreText.text = ""+ finalScore;
		finalCoinText.text = "" + finalCoinScore;
		StartCoroutine (ShowMainMenu ());
	}

	IEnumerator ShowMainMenu(){
		yield return new WaitForSeconds (3f);
		SceneManager.LoadScene ("MainMenu");
	}

	public void RestartGame(){
		StartCoroutine (Restart ());
	}

	IEnumerator Restart(){
		yield return new WaitForSeconds (1f);
		SceneManager.LoadScene ("GamePlay");
	}

	public void PauseGame(){
		Time.timeScale = 0;
		pausePanel.SetActive (true);
	}

	public void ResumeGame(){
		Time.timeScale = 1;
		pausePanel.SetActive (false);
	}

	public void QuitGame(){
		Time.timeScale = 1;
		SceneManager.LoadScene("MainMenu");
	}

	public void SetScore(int score){
		scoreText.text = "x" + score;
	}

	public void SetLife(int life){
		lifeText.text = "x" + life;
	}

	public void SetCoin(int coin){
		coinText.text = "x" + coin;
	}

	public void Ready(){
		Time.timeScale = 1;
		readyButton.SetActive (false);
	}
}
