using UnityEngine;
using System.Collections;

public class BGScaler : MonoBehaviour {

	// Use this for initialization
	void Start () {

		//resizing background to fit the camera
		SpriteRenderer renderer = GetComponent<SpriteRenderer> ();

		//the width of the background sprite
		float spriteWidth = renderer.bounds.size.x;

		//the height of the ortographic camera
		float worldHeight = Camera.main.orthographicSize * 2.0f;
		//the width of the ortographic camera
		float worldWidth = worldHeight * Camera.main.aspect;

		Vector3 tempScale = transform.localScale;
		tempScale.x = worldWidth / spriteWidth;
		transform.localScale = tempScale;
	}

}
