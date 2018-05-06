using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour {
	private float height;
	private List<GameObject> connectedObjects;
	public float speed = 1.0f;
	public float newSpeed = 3.0f;
	private bool removedHand = false;
	private enum Direction {Left, Right, Neutral};
	private Direction direction;

	// Use this for initialization
	void Start () {
		height = 0;
		direction = Direction.Neutral;
		connectedObjects = new List<GameObject> ();
		connectedObjects.Add (getHand ());
	}
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate () 
	{
		if (direction == Direction.Left) {
			moveLeft ();
		} 
		else if (direction == Direction.Right) {
			moveRight ();
		}
	}
	public void setLeft (){
		direction = Direction.Left;
	}
	public void setRight(){
		direction = Direction.Right;
	}
	public void setNeutral (){
		direction = Direction.Neutral;
	}
	private void moveLeft (){
		var controlledTransform = connectedObjects [0].transform;
		var xPosition = controlledTransform.position.x;
		if (xPosition > -15) {
			var moveVector = new Vector3 (getSpeed(), 0, 0);
			controlledTransform.position = controlledTransform.position - moveVector;
		}
	}
	private void moveRight (){
		var controlledTransform = connectedObjects [0].transform;
		var xPosition = controlledTransform.position.x;
		if (xPosition < 15) {
			var moveVector = new Vector3 (getSpeed(), 0, 0);
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
