using UnityEngine;
using System.Collections;

public class BGCollector : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D collider){
		if (collider.tag == "Background") {
			collider.gameObject.SetActive (false);
		}
	}
}
