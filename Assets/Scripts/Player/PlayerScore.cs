using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour {

	[SerializeField]
	private AudioClip coinClip;
	[SerializeField]
	private AudioClip lifeClip;
	[SerializeField]
	private AudioClip deathClip;

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

		GameplayController.instance.SetCoin (coinCount);
		GameplayController.instance.SetLife (lifeCount);
		GameplayController.instance.SetScore (scoreCount);
	}
	
	// Update is called once per frame
	void Update () {
		CountScore ();
	}

	void CountScore(){
		if (countScore){
			if (transform.position.y < lastPosition.y) {
				scoreCount++;
			}
			lastPosition = transform.position;

			GameplayController.instance.SetScore (scoreCount);
		}
	}

	void OnTriggerEnter2D (Collider2D collider){
		switch (collider.tag) {
		case "Coin":
			coinCount++;
			scoreCount += 200;

			GameplayController.instance.SetCoin (coinCount);

			AudioSource.PlayClipAtPoint (coinClip, transform.position);
			collider.gameObject.SetActive (false);
			break;
		case "Life":
			lifeCount++;
			scoreCount += 500;

			GameplayController.instance.SetLife (lifeCount);

			AudioSource.PlayClipAtPoint (lifeClip, transform.position);
			collider.gameObject.SetActive (false);
			break;
		case "Bounds":
			HandleDeath ();
			break;
		case "Deadly":
			HandleDeath ();
			break;
		}
	}

	void HandleDeath(){
		cameraScript.moveCamera = false;
		countScore = false;

		AudioSource.PlayClipAtPoint (deathClip, transform.position);

		lifeCount--;
		transform.position = new Vector3 (500, 500, 0);
		//GameplayController.instance.ShowGameOverPanel (scoreCount, coinCount);
		GameManager.instance.CheckGameStatus(scoreCount, lifeCount, coinCount);
	}
}
