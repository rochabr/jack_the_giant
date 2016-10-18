using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	void MakeSingleton(){
		if (instance != null) {
			DestroyObject (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
		
	}

	// Use this for initialization
	void Awake () {
		MakeSingleton ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
