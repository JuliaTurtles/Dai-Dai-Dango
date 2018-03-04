using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour {
	public float moveSpeed = 10.0f;
	private float height;
	private bool dead = false;
	private Vector3 moveVector = Vector3.zero;

	// Use this for initialization
	void Start () {
		height = 0;
	}

	void Update () 
	{
		moveVector.x = -Input.acceleration.y * moveSpeed;
		if (moveVector.x != 0) {
			print ("Moving");
			print (moveVector.x);
		}

		var xPosition = transform.position.x;
		var left = moveVector.x < 0;
		var right = moveVector.x > 0;

		if (left && xPosition > -15)
		{			
			transform.position = transform.position - moveVector;
		}
		if (right && xPosition < 15) {
			transform.position = transform.position + moveVector;
		}
	}

	public float getHeight () {
		return height;
	}

	public void addDangoHeight(float dangoHeight) {
		height += dangoHeight;
	}
}
