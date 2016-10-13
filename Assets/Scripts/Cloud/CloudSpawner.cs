﻿using UnityEngine;
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
		controlX = 0f;

		SetMinAndMaxX ();
		CreateClouds ();

		player = GameObject.Find ("Player");

	}

	void Start () {
		PositionPlayer ();
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

			if (controlX == 0) {
				temp.x = Random.Range (0.0f, maxX);
				controlX = 1;
			} else if (controlX == 1) {
				temp.x = Random.Range (0.0f, minX);
				controlX = 2;
			} else if (controlX == 2) {
				temp.x = Random.Range (1.0f, maxX);
				controlX = 3;
			} else if (controlX == 3) {
				temp.x = Random.Range (-1.0f, minX);
				controlX = 0;
			}

			lastCloudPositionY = temp.y;
			clouds [i].transform.position = temp;

			positionY -= distanceBetweenCLouds;
		}
	}

	void PositionPlayer(){
		GameObject[] darkClouds = GameObject.FindGameObjectsWithTag ("Deadly");
		GameObject[] cloudsInGame = GameObject.FindGameObjectsWithTag ("Cloud");

		GameObject firstCloud = null;

		//lops the dark clouds array and checks if any of them is in the first position of the game,
		//if it is, changes its position with the first white cloud
		for (int i = 0; i < darkClouds.Length; i++) {
			if (darkClouds [i].transform.position.y == 0f) {
				Vector3 temporaryPosition = darkClouds [i].transform.position;
					
				darkClouds [i].transform.position = new Vector3 (cloudsInGame [0].transform.position.x,
					cloudsInGame [0].transform.position.y, 
					cloudsInGame [0].transform.position.z);

				cloudsInGame [0].transform.position = temporaryPosition;
			}
		}

		//position player on the first cloud
		for (int i = 0; i < clouds.Length; i++) {
			if (clouds [i].transform.position.y == 0f) {
				firstCloud = clouds [i];
				break;
			}
		}

		if (firstCloud != null) {
			player.transform.position = new Vector3(firstCloud.transform.position.x, 
				(firstCloud.transform.position.y + player.GetComponent<SpriteRenderer>().bounds.size.y / 2) , 
				firstCloud.transform.position.z);
		}
	}

}