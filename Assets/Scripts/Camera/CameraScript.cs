using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	private float speed = 1f;
	private float acceleration = 0.2f;
	private float maxSpeed = 3.2f;

	[HideInInspector]
	public bool moveCamera;

	// Use this for initialization
	void Start () {
		moveCamera = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (moveCamera) {
			MoveCamera ();
		}
	}

	void MoveCamera(){
		Vector3 tempPosition = transform.position;
		float oldY = tempPosition.y;
		float newY = tempPosition.y - (speed * Time.deltaTime);

		tempPosition.y = Mathf.Clamp (tempPosition.y, oldY, newY);
		transform.position = tempPosition;

		speed += acceleration * Time.deltaTime;

		if (speed > maxSpeed) {
			speed = maxSpeed;
		}

	}
}
