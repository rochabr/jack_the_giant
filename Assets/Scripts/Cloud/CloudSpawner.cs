using UnityEngine;
using System.Collections;

public class CloudSpawner : MonoBehaviour {

	[SerializeField]
	private GameObject[] clouds;

	[SerializeField]
	private GameObject[] collectables;

	private GameObject player;

	private float minX;
	private float maxX;

	private float lastCloudPositionY;
	private float distanceBetweenCLouds = 3f;

	private float controlX;

	// Use this for initialization
	void Awake () {
		SetMinAndMaxX ();
	}

	void SetMinAndMaxX(){
		Vector3 bounds = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));
		maxX = bounds.x - 0.5f;
		minX = -bounds.x + 0.5f;
	}

	void Shuffle(GameObject[] cloudArray){
		for (int i = 0; i < cloudArray.Length; i++) {
			GameObject tempCloud = cloudArray [i];
			int random = Random.Range (i, cloudArray.Length);
			cloudArray [i] = cloudArray [random];
			clouds [random] = tempCloud;
		}
	}

	void CreateClouds(){
		Shuffle (clouds);

		float positionY = 0f;

		for (int i = 0; i < clouds.Length; i++) {
			Vector3 temp = clouds [i].transform.position;
			temp.y = positionY;
			temp.x = Random.Range (minX, maxX);

			lastCloudPositionY = temp.y;

			clouds [i].transform.position = temp;
		}
	}

}
