using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
	public GameObject[] availableScreens;
	public List<GameObject> currentScreens;
	private float screenHeightInPoints;

	// Use this for initialization
	void Start () {
		screenHeightInPoints = 2.0f * Camera.main.orthographicSize;
	}

	// Update is called once per frame

	void Update () {

	}

	void FixedUpdate () {    
		var cameraHeight = getCameraHeight ();
		var screenHeight = maxScreenHeight ();
		if (cameraHeight > screenHeight / 2) {
			Debug.Log("new screen");
			var index = Random.Range (0, availableScreens.Length);
			var newScreen = availableScreens [index];
			var gameObject = Instantiate (newScreen);
			gameObject.transform.position = new Vector3 (0, screenHeight + 60.9f);
			currentScreens.Add (gameObject);

		}
	}
	private float getCameraHeight(){
		return Camera.main.gameObject.transform.position.y; 
	}
	private float maxScreenHeight(){
		var max = 0.0f;
		foreach (var screen in currentScreens) {
			var screenHeight = screen.transform.position.y;
			if (screenHeight > max) {
				max = screenHeight;
			}
		}
		return max;
	} 
}
