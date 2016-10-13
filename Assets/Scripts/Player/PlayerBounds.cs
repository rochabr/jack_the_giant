using UnityEngine;
using System.Collections;

public class PlayerBounds : MonoBehaviour {

	private float minX;
	private float maxX;

	// Use this for initialization
	void Start () {
		SetMinAndMaxXBounds ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentPosition = transform.position;
		if (currentPosition.x < minX) {
			currentPosition.x = minX;
		}else if (currentPosition.x > maxX) {
			currentPosition.x = maxX;
		}

		transform.position = currentPosition;
	}

	void SetMinAndMaxXBounds ()
	{
		Vector3 bounds = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));
		maxX = bounds.x;
		minX = -bounds.x;
	}
}
