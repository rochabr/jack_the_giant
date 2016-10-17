using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour {

	[SerializeField]
	private AudioClip coinClip;
	[SerializeField]
	private AudioClip lifeClip;

	private CameraScript cameraScript;
	private Vector3 lastPosition;

	private bool countScore;

	public static int scoreCount;
	public static int lifeCount;
	public static int coinCount;

	void Awake () {
		cameraScript = Camera.main.GetComponent<CameraScript> ();
	}
		

	// Use this for initialization
	void Start () {
		//setting previous position to be the current position
		lastPosition = transform.position;
		countScore = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void CoutnScore(){
		if (countScore){
			if (transform.position.y < lastPosition.y) {
				coinCount++;
			}
			lastPosition = transform.position;
		}
	}

	void OnTriggerEnter2D (Collider2D collider){
		switch (collider.tag) {
		case "Coin":
			coinCount++;
			scoreCount += 200;

			AudioSource.PlayClipAtPoint (coinClip, transform.position);
			collider.gameObject.SetActive (false);
			break;
		case "Life":
			lifeCount++;
			scoreCount += 500;

			AudioSource.PlayClipAtPoint (lifeClip, transform.position);
			collider.gameObject.SetActive (false);
			break;
		case "Bounds":
			cameraScript.moveCamera = false;
			countScore = false;

			lifeCount--;
			transform.position = new Vector3 (500, 500, 0);
			break;
		case "Deadly":
			cameraScript.moveCamera = false;
			countScore = false;

			lifeCount--;
			transform.position = new Vector3 (500, 500, 0);
			break;
		}
	}
}
