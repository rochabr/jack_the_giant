using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 5.0f;
	public float maxVelocity = 4.0f;

	//[SerializeField]
	private Rigidbody2D rigidBody;
	private Animator animator;

	void Awake (){
		rigidBody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		PlayerMoveKeyboard();
	}

	void PlayerMoveKeyboard(){
		float forceX = 0f;
		//return positive rigid body number
		float velocity = Mathf.Abs (rigidBody.velocity.x);

		float direction = Input.GetAxis ("Horizontal");
		if (direction > 0) {
			if (velocity < maxVelocity) {
				forceX = speed;
			}

			//changing sprite direction
			Vector3 tempScale = transform.localScale;
			tempScale.x = Mathf.Abs(transform.localScale.x);
			transform.localScale = tempScale;

			animator.SetBool ("Walk", true);
		} else if (direction < 0) {
			if (velocity < maxVelocity) {
				forceX = -speed;
			}

			//changing sprite direction
			Vector3 tempScale = transform.localScale;
			tempScale.x = -1 * Mathf.Abs(transform.localScale.x);
			transform.localScale = tempScale;

			animator.SetBool ("Walk", true);
		} else {
			animator.SetBool ("Walk", false);
		}

		rigidBody.AddForce(new Vector2(forceX, 0));
	}
}
