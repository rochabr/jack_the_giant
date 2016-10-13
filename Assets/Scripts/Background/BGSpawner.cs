using UnityEngine;
using System.Collections;

public class BGSpawner : MonoBehaviour {

	private GameObject[] backgrounds;
	private float lastY;

	// Use this for initialization
	void Start () {
		GetBackgroundAndSetLastY ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Background" && collider.transform.position.y == lastY) {
			Vector3 tempPosition = collider.transform.position;
			float bgHeight = ((BoxCollider2D)collider).size.y;

			foreach (GameObject bg in backgrounds) {
				if (!bg.activeInHierarchy) {
					tempPosition.y -= bgHeight;
					lastY = tempPosition.y;

					bg.transform.position = tempPosition;
					bg.SetActive (true);
				}
			}
		}
	}

	void GetBackgroundAndSetLastY(){
		backgrounds = GameObject.FindGameObjectsWithTag ("Background");
		lastY = GetLastBackgroundPosition ();
	}

	float GetLastBackgroundPosition ()
	{
		float y = 0f;
		foreach (GameObject bg in backgrounds) {
			if (y > bg.transform.position.y) {
				y = bg.transform.position.y;
			}
		}

		return y;
	}
}
