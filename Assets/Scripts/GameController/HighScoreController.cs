using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour {

	[SerializeField]
	private Text scoreText;

	[SerializeField]
	private Text coinText;


	// Use this for initialization
	void Start () {
		SetDifficultyScore ();
	}

	public void SetScore(int score, int coinScore){
		scoreText.text = score.ToString ();
		coinText.text = coinScore.ToString ();
	}

	public void SetDifficultyScore(){
		switch (GamePreferences.GetDifficultyState ()) {
		case StaticProperties.EASY_MODE:
			SetScore (GamePreferences.GetEasyDifficultyHighScore(), GamePreferences.GetEasyDifficultyCoinScore());
			break;
		case StaticProperties.MEDIUM_MODE:
			SetScore (GamePreferences.GetMediumDifficultyHighScore(), GamePreferences.GetMediumDifficultyCoinScore());
			break;
		case StaticProperties.HARD_MODE:
			SetScore (GamePreferences.GetHardDifficultyHighScore(), GamePreferences.GetHardDifficultyCoinScore());
			break;
		}
//		if (GamePreferences.GetEasyDifficultyState () == 1) {
//			SetScore (GamePreferences.GetEasyDifficultyHighScore(), GamePreferences.GetEasyDifficultyCoinScore());
//		}
//
//		if (GamePreferences.GetMediumDifficultyState () == 1) {
//			SetScore (GamePreferences.GetMediumDifficultyHighScore(), GamePreferences.GetMediumDifficultyCoinScore());
//		}
//
//		if (GamePreferences.GetHardDifficultyState () == 1) {
//			SetScore (GamePreferences.GetHardDifficultyHighScore(), GamePreferences.GetHardDifficultyCoinScore());
//		}
	}

	public void GoBack(){
		SceneManager.LoadScene ("MainMenu");
	}
}
