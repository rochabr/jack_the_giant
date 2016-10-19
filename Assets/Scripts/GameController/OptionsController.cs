using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour {

	[SerializeField]
	private GameObject easySign;

	[SerializeField]
	private GameObject mediumSign;

	[SerializeField]
	private GameObject hardSign;

	// Use this for initialization
	void Start () {
		SetDifficulty();
	}

//	void SetInitialDifficulty(string difficulty){
//		switch (difficulty) {
//		case "easy":
//			easySign.SetActive (true);
//			mediumSign.SetActive (false);
//			hardSign.SetActive (false);
//			break;
//		case "medium":
//			easySign.SetActive (false);
//			mediumSign.SetActive (true);
//			hardSign.SetActive (false);
//			break;
//		case "hard":
//			easySign.SetActive (false);
//			mediumSign.SetActive (false);
//			hardSign.SetActive (true);
//			break;
//		}
//	}

	void SetDifficulty(){
		switch (GamePreferences.GetDifficultyState ()) {
		case StaticProperties.EASY_MODE:
			easySign.SetActive (true);
			mediumSign.SetActive (false);
			hardSign.SetActive (false);
			break;
		case StaticProperties.MEDIUM_MODE:
			easySign.SetActive (false);
			mediumSign.SetActive (true);
			hardSign.SetActive (false);
			break;
		case StaticProperties.HARD_MODE:
			easySign.SetActive (false);
			mediumSign.SetActive (false);
			hardSign.SetActive (true);
			break;
		}

//		if (GamePreferences.GetEasyDifficultyState () == 1) {
//			SetInitialDifficulty ("easy");
//		}else if (GamePreferences.GetMediumDifficultyState () == 1) {
//			SetInitialDifficulty ("medium");
//		}else if (GamePreferences.GetHardDifficultyState () == 1) {
//			SetInitialDifficulty ("hard");
//		}
	}

	public void SetEasyDifficulty(){
//		GamePreferences.SetEasyDifficultyState (1);
//		GamePreferences.SetMediumDifficultyState (0);
//		GamePreferences.SetHardDifficultyState (0);

		GamePreferences.SetDifficultyState (StaticProperties.EASY_MODE);

		SetDifficulty ();
	}

	public void SetMediumDifficulty(){
//		GamePreferences.SetEasyDifficultyState (0);
//		GamePreferences.SetMediumDifficultyState (1);
//		GamePreferences.SetHardDifficultyState (0);
//
		GamePreferences.SetDifficultyState (StaticProperties.MEDIUM_MODE);

		SetDifficulty ();
	}

	public void SetHardDifficulty(){
//		GamePreferences.SetEasyDifficultyState (0);
//		GamePreferences.SetMediumDifficultyState (0);
//		GamePreferences.SetHardDifficultyState (1);

		GamePreferences.SetDifficultyState (StaticProperties.HARD_MODE);

		SetDifficulty ();
	}
	
	public void GoBack(){
		SceneManager.LoadScene ("MainMenu");
	}
}
