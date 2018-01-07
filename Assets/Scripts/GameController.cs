using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	private float height;
	public List<GameObject> currentObjects;


	// Use this for initialization
	void Start () {
		height = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate () 
	{
		bool left = Input.GetKey(KeyCode.LeftArrow);
		bool right = Input.GetKey(KeyCode.RightArrow);
		var moveVector = new Vector3 (1, 0, 0);
		var controlledObject = currentObjects[0];
		var xPosition = controlledObject.transform.position.x;

		if (left && xPosition > -15)
		{			
			controlledObject.transform.position = controlledObject.transform.position - moveVector;
		}
		if (right && xPosition < 15) {
			controlledObject.transform.position = controlledObject.transform.position + moveVector;
		}
	}
	public float getHeight () {
		return height;
	}

	public void addDangoHeight(float dangoHeight) {
		height += dangoHeight;
	}
	public void addObject(GameObject obj) {
		currentObjects.Add (obj);
		if (currentObjects.Count > 20) {
			var firstObject = currentObjects [0];
			Destroy (firstObject);
			currentObjects.RemoveAt (0);
		}
	}
}
