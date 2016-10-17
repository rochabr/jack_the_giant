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
		controlX = 0f;

		SetMinAndMaxX ();
		CreateClouds ();

		player = GameObject.Find ("Player");

		//deactivate collactables
		foreach (GameObject col in collectables) {
			col.SetActive (false);
		}

	}

	void Start () {
		PositionPlayer ();
	}
		

	void SetMinAndMaxX(){
		Vector3 bounds = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));
		maxX = bounds.x - 0.5f;
		minX = -bounds.x + 0.5f;
	}

	void Shuffle(GameObject[] array){
		for (int i = 0; i < array.Length; i++) {
			GameObject tempCloud = array [i];
			int random = Random.Range (i, array.Length);
			array [i] = array [random];
			clouds [random] = tempCloud;
		}
	}

	void CreateClouds(){
		Shuffle (clouds);

		float positionY = 0f;

		foreach (GameObject cloud in clouds) {
			Vector3 temp = cloud.transform.position;
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
			cloud.transform.position = temp;

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

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Cloud" || collider.tag == "Deadly") {
			if (collider.transform.position.y == lastCloudPositionY) {
				Shuffle (clouds);
				//Shuffle (collectables);

				Vector3 tempPosition = collider.transform.position;

				foreach (GameObject cloud in clouds) {
					if (!cloud.activeInHierarchy) {
						if (controlX == 0) {
							tempPosition.x = Random.Range (0.0f, maxX);
							controlX = 1;
						} else if (controlX == 1) {
							tempPosition.x = Random.Range (0.0f, minX);
							controlX = 2;
						} else if (controlX == 2) {
							tempPosition.x = Random.Range (1.0f, maxX);
							controlX = 3;
						} else if (controlX == 3) {
							tempPosition.x = Random.Range (-1.0f, minX);
							controlX = 0;
						}

						tempPosition.y -= distanceBetweenCLouds;
						lastCloudPositionY = tempPosition.y;

						cloud.transform.position = tempPosition;
						cloud.SetActive (true);

						int random = Random.Range (0, collectables.Length);
						if (cloud.tag != "Deadly" && !collectables[random].activeInHierarchy) {
							Vector3 temp = cloud.transform.position;
							temp.y += 0.7f;

							if (collectables [random].tag == "Life") {
								if (PlayerScore.lifeCount < 2) {
									collectables [random].transform.position = temp;
									collectables [random].SetActive (true);
								}
							} else {
								collectables [random].transform.position = temp;
								collectables [random].SetActive (true);
							}
						}
					}
				}
			}	
		}
	}

}
