using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 5.0f;
	public float maxVelocity = 4.0f;

	//[SerializeField]
	private Rigidbody2D rigidBody;
	private Animator animator;

	private bool moveLeft;
	private bool moveRight;

	void Awake (){
		rigidBody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (moveLeft) {
			MoveLeft ();
		} else if (moveRight) {
			MoveRight ();
		}
	}

	public void SetMoveLeft(bool moveLeft){
		this.moveLeft = moveLeft;
		this.moveRight = !moveLeft;
	}

	public void MoveRight(){
		float forceX = 0f;
		//return positive rigid body number
		float velocity = Mathf.Abs (rigidBody.velocity.x);
		if (velocity < maxVelocity) {
			forceX = speed;
		}

		//changing sprite direction
		Vector3 tempScale = transform.localScale;
		tempScale.x = Mathf.Abs (transform.localScale.x);
		transform.localScale = tempScale;

		animator.SetBool ("Walk", true);
		rigidBody.AddForce(new Vector2(forceX, 0));
	}

	public void MoveLeft(){
		float forceX = 0f;
		//return positive rigid body number
		float velocity = Mathf.Abs (rigidBody.velocity.x);

		if (velocity < maxVelocity) {
			forceX = -speed;
		}

		//changing sprite direction
		Vector3 tempScale = transform.localScale;
		tempScale.x = -1 * Mathf.Abs(transform.localScale.x);
		transform.localScale = tempScale;

		animator.SetBool ("Walk", true);
		rigidBody.AddForce(new Vector2(forceX, 0));
	}

	public void StopWalking(){
		moveLeft = moveRight = false;
		animator.SetBool ("Walk", false);
	}
	

}
