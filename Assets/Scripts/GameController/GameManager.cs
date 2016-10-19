using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	[HideInInspector]
	public bool gameStartedFromMenu;
	[HideInInspector]
	public bool gameRestarted;

	[HideInInspector]
	public int score;
	[HideInInspector]
	public int coinScore;
	[HideInInspector]
	public int lifeScore;

	void MakeSingleton(){
		if (instance != null) {
			DestroyObject (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	void InitializePreferences(){
		if (!PlayerPrefs.HasKey ("GameInitialized")) {
			GamePreferences.SetDifficultyState (StaticProperties.MEDIUM_MODE);

			//GamePreferences.SetEasyDifficultyState (0);
			GamePreferences.SetEasyDifficultyHighScore (0);
			GamePreferences.SetEasyDifficultyCoinScore (0);

			//GamePreferences.SetMediumDifficultyState (1);
			GamePreferences.SetMediumDifficultyHighScore (0);
			GamePreferences.SetMediumDifficultyCoinScore (0);

			//GamePreferences.SetHardDifficultyState (0);
			GamePreferences.SetHardDifficultyHighScore (0);
			GamePreferences.SetHardDifficultyCoinScore (0);

			GamePreferences.SetMusicState (0);

			PlayerPrefs.SetInt("GameInitialized", 1);
		}
	}

	void OnLevelWasLoaded(){
		if (SceneManager.GetActiveScene().name ==  "GamePlay") {
			if (gameRestarted) {
				GameplayController.instance.SetScore (score);
				GameplayController.instance.SetLife (lifeScore);
				GameplayController.instance.SetCoin (coinScore);

				PlayerScore.scoreCount = score;
				PlayerScore.coinCount = coinScore;
				PlayerScore.lifeCount = lifeScore;
			} else if (gameStartedFromMenu) {
				PlayerScore.coinCount = 0;
				PlayerScore.scoreCount = 0;
				PlayerScore.lifeCount = 2;

				GameplayController.instance.SetScore (0);
				GameplayController.instance.SetCoin (0);
				GameplayController.instance.SetLife (2);
			}
		}
	}

	public void CheckGameStatus(int score, int lifeScore, int coinScore){
		if (lifeScore < 0) {
			gameRestarted = false;
			gameStartedFromMenu = false;

			GameplayController.instance.ShowGameOverPanel (score, coinScore);
		} else {
			this.score = score;
			this.lifeScore = lifeScore;
			this.coinScore = coinScore;

			gameRestarted = true;
			gameStartedFromMenu = false;

			GameplayController.instance.RestartGame ();
		}
	}

	// Use this for initialization
	void Awake () {
		MakeSingleton ();
	}

	void Start(){
		InitializePreferences ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
