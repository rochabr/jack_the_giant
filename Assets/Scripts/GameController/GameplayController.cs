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
	private GameObject pausePanel;

	private static GameplayController instance;

	void Awake(){
		CreateInstance ();
	}

	void CreateInstance(){
		if (instance == null) {
			instance = this;
		}
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
}
