using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour {

	[SerializeField]
	private Button musicButton;

	[SerializeField]
	private Sprite[] musicIcons;

	// Use this for initialization
	void Start () {
		ShouldPlayMusic();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ShouldPlayMusic(){
		if (GamePreferences.GetMusicState () == 1) {
			MusicController.instance.PlayMusic (true);
			musicButton.image.sprite = musicIcons [0];
		} else {
			MusicController.instance.PlayMusic (false);
			musicButton.image.sprite = musicIcons [1];
		}
	}

	public void StartGame(){
		GameManager.instance.gameStartedFromMenu = true;
		SceneManager.LoadScene ("GamePlay");
	}

	public void HighScore(){
		SceneManager.LoadScene ("HighScore");
	}

	public void Options(){
		SceneManager.LoadScene ("OptionsMenu");
	}

	public void Sound(){
		if (GamePreferences.GetMusicState () == 0) {
			GamePreferences.SetMusicState (1);
		}else {
			GamePreferences.SetMusicState (0);
		}

		ShouldPlayMusic ();
	}
}
