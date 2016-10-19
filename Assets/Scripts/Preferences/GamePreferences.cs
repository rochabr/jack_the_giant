using UnityEngine;
using System.Collections;

public class GamePreferences : MonoBehaviour {

	public static string Difficulty = "Difficulty";

//	public static string EasyDifficulty = "EasyDifficulty";
//	public static string MediumDifficulty = "MediumDifficulty";
//	public static string HardDifficulty = "HardDifficulty";

	public static string EasyDifficultyHighScore = "EasyDifficultyHighScore";
	public static string MediumDifficultyHighScore = "MediumDifficultyHighScore";
	public static string HardDifficultyHighScore = "HardDifficultyHighScore";

	public static string EasyDifficultyCoinScore = "EasyDifficultyCoinScore";
	public static string MediumDifficultyCoinScore = "MediumDifficultyCoinScore";
	public static string HardDifficultyCoinScore = "HardDifficultyCoinScore";

	public static string IsMusicOn = "IsMusicOn";

	public static int GetMusicState(){
		return PlayerPrefs.GetInt (GamePreferences.IsMusicOn);
	}

	public static void SetMusicState(int state){
		PlayerPrefs.SetInt (GamePreferences.IsMusicOn, state);
	}

	#region difficulty

	/* 
	 * 0 - easy
	 * 1 - medium
	 * 2 - hard 
	*/

	public static int GetDifficultyState(){
		return PlayerPrefs.GetInt (GamePreferences.Difficulty);
	}

	public static void SetDifficultyState(int state){
		PlayerPrefs.SetInt (GamePreferences.Difficulty, state);
	}

//	public static int GetEasyDifficultyState(){
//		return PlayerPrefs.GetInt (GamePreferences.EasyDifficulty);
//	}
//
//	public static void SetEasyDifficultyState(int state){
//		PlayerPrefs.SetInt (GamePreferences.EasyDifficulty, state);
//	}

//	public static int GetMediumDifficultyState(){
//		return PlayerPrefs.GetInt (GamePreferences.MediumDifficulty);
//	}
//
//	public static void SetMediumDifficultyState(int state){
//		PlayerPrefs.SetInt (GamePreferences.MediumDifficulty, state);
//	}
//
//	public static int GetHardDifficultyState(){
//		return PlayerPrefs.GetInt (GamePreferences.HardDifficulty);
//	}
//
//	public static void SetHardDifficultyState(int state){
//		PlayerPrefs.SetInt (GamePreferences.HardDifficulty, state);
//	}

	#endregion

	#region highscore

	public static int GetEasyDifficultyHighScore(){
		return PlayerPrefs.GetInt (GamePreferences.EasyDifficultyHighScore);
	}

	public static void SetEasyDifficultyHighScore(int score){
		PlayerPrefs.SetInt (GamePreferences.EasyDifficultyHighScore, score);
	}

	public static int GetMediumDifficultyHighScore(){
		return PlayerPrefs.GetInt (GamePreferences.MediumDifficultyHighScore);
	}

	public static void SetMediumDifficultyHighScore(int score){
		PlayerPrefs.SetInt (GamePreferences.MediumDifficultyHighScore, score);
	}

	public static int GetHardDifficultyHighScore(){
		return PlayerPrefs.GetInt (GamePreferences.HardDifficultyHighScore);
	}

	public static void SetHardDifficultyHighScore(int score){
		PlayerPrefs.SetInt (GamePreferences.HardDifficultyHighScore, score);
	}

	#endregion

	#region coin score

	public static int GetEasyDifficultyCoinScore(){
		return PlayerPrefs.GetInt (GamePreferences.EasyDifficultyCoinScore);
	}

	public static void SetEasyDifficultyCoinScore(int coin){
		PlayerPrefs.SetInt (GamePreferences.EasyDifficultyCoinScore, coin);
	}

	public static int GetMediumDifficultyCoinScore(){
		return PlayerPrefs.GetInt (GamePreferences.MediumDifficultyCoinScore);
	}

	public static void SetMediumDifficultyCoinScore(int coin){
		PlayerPrefs.SetInt (GamePreferences.MediumDifficultyCoinScore, coin);
	}

	public static int GetHardDifficultyCoinScore(){
		return PlayerPrefs.GetInt (GamePreferences.HardDifficultyCoinScore);
	}

	public static void SetHardDifficultyCoinScore(int coin){
		PlayerPrefs.SetInt (GamePreferences.HardDifficultyCoinScore, coin);
	}

	#endregion
}
