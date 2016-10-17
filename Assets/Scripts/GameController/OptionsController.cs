using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public void GoBack(){
		SceneManager.LoadScene ("MainMenu");
	}
}
