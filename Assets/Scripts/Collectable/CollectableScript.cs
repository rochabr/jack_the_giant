using UnityEngine;
using System.Collections;

public class CollectableScript : MonoBehaviour {

	void OnEnable(){
		//when the collectable appears, deactivate it after 4 seconds
		Invoke ("DestroyCollectable", 6f);
	}

	void DestroyCollectable(){
		gameObject.SetActive (false);
	}
}
