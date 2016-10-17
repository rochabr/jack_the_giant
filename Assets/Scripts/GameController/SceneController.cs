using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame(){
		SceneManager.LoadScene ("GamePlay");
	}

	public void HighScore(){
		SceneManager.LoadScene ("HighScore");
	}

	public void Options(){
		SceneManager.LoadScene ("OptionsMenu");
	}

	public void Sound(){
		//SceneManager.LoadScene ("OptionsMenu");
	}
}
