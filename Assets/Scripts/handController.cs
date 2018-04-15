using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour {
	private float height;
	private List<GameObject> connectedObjects;
	public float speed = 1.0f;
	public float newSpeed = 3.0f;
	private bool removedHand = false;
	private Vector3 moveVector = Vector3.zero;

	// Use this for initialization
	void Start () {
		height = 0;
		connectedObjects = new List<GameObject> ();
		connectedObjects.Add (getHand ());
	}

	void Update () 
	{
		var controlledTransform = connectedObjects [0].transform;
		var xPosition = controlledTransform.position.x;
		moveVector.x = -Input.acceleration.y * getSpeed();
		if (moveVector.x != 0) {
			print ("Moving");
			print (moveVector.x);
		}
			
		var left = moveVector.x < 0;
		var right = moveVector.x > 0;

		if (left && xPosition > -15)
		{			
			controlledTransform.position = controlledTransform.position - moveVector;
		}
		if (right && xPosition < 15) {
			controlledTransform.position = controlledTransform.position + moveVector;
		}
	}

	public float getHeight () {
		return height;
	}
	public void addDango(GameObject dango, float dangoHeight) {
		height += dangoHeight;
		connectedObjects.Add (dango);
		if (connectedObjects.Count > 20) {
			var firstObject = connectedObjects [0];
			connectedObjects.RemoveAt (0);
			Destroy (firstObject);
			removedHand = true;
		}
	}
	private float getSpeed () {
		if (removedHand) {
			return newSpeed;
		} else {
			return speed;
		}
	}
	private GameObject getHand() {
		return GameObject.Find ("Hand");
	}
}
