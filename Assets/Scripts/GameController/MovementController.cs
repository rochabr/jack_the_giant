using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MovementController : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {

	private PlayerController playerController;

	// Use this for initialization
	void Start () {
		playerController = GameObject.Find ("Player").GetComponent<PlayerController> ();
	}
	
	public void OnPointerDown(PointerEventData data){
		if (gameObject.name == "Left") {
			playerController.SetMoveLeft (true);
		} else {
			playerController.SetMoveLeft (false);
		}
	}

	public void OnPointerUp(PointerEventData data){
		playerController.StopWalking ();
	}
}
