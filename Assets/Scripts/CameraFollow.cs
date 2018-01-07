using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public GameController controller;
	private float initialCameraHeight;

	// Use this for initialization
	void Start () {
		initialCameraHeight = transform.position.y;
	}

	// Update is called once per frame
	void Update () {
		var currentHeight = transform.position.y;
		var expectedHeight = initialCameraHeight + controller.getHeight ();
	
		if (currentHeight < expectedHeight) {
			transform.position = new Vector3 (transform.position.x, transform.position.y + (Time.deltaTime * controller.getHeight()), transform.position.z);
		}
	}
}