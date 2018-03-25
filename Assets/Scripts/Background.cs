using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
	public GameObject[] availableScreens;
	public List<GameObject> currentScreens;
	private float screenHeightInPoints;
	public GameObject[] availablePlanets;
	public GameObject star;

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
			addPlanets ();
			addStars ();
			currentScreens.Add (gameObject);

		}
	}
	private void addPlanets(){
		var numPlanets = Mathf.Floor (Random.value * 3 + 1);
		for (var i = 0; i < numPlanets; i++) {
			var xCoordinate = Random.Range (-15.0f, 15.0f);
			var yCoordinate = Random.Range (maxScreenHeight(), maxScreenHeight() + 60.9f);
			var scale = Random.Range (0.5f, 1.5f);
			var index = Random.Range (0, availablePlanets.Length);
			var newPlanet = availablePlanets [index];
			var gameObject = Instantiate (newPlanet);
			gameObject.transform.position = new Vector3 (xCoordinate, yCoordinate);
			gameObject.transform.localScale = new Vector3 (scale, scale);
		}
	}
	private void addStars(){
		var numStars = Mathf.Floor (Random.value * 25 + 1);
		for (var i = 0; i < numStars; i++) {
			var xCoordinate = Random.Range (-15.0f, 15.0f);
			var yCoordinate = Random.Range (maxScreenHeight(), maxScreenHeight() + 60.9f);
			var scale = Random.Range (0.4f, 0.6f);
			var gameObject = Instantiate (star);
			gameObject.transform.position = new Vector3 (xCoordinate, yCoordinate);
			gameObject.transform.localScale = new Vector3 (scale, scale);
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
