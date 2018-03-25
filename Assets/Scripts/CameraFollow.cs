using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	private HandController hand;
	private float initialCameraHeight;

	// Use this for initialization
	void Start () {
		hand = GameObject.Find ("Player").GetComponent<HandController> ();
		initialCameraHeight = transform.position.y;
	}

	// Update is called once per frame
	void Update () {
		var currentHeight = transform.position.y;
		var expectedHeight = initialCameraHeight + hand.getHeight ();

		if (currentHeight < expectedHeight) {
			transform.position = new Vector3 (transform.position.x, transform.position.y + (Time.deltaTime * hand.getHeight()), transform.position.z);
		}
	}
}