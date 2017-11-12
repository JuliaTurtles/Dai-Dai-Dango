using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handController : MonoBehaviour {
	public float jetpackForce = 75.0f;
	public float forwardMovementSpeed = 3.0f;
	private bool dead = false;

	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision collision) {
		print ("Ouch");
	}

	void FixedUpdate () 
	{
		bool left = Input.GetKey(KeyCode.LeftArrow);
		bool right = Input.GetKey(KeyCode.RightArrow);
		var moveVector = new Vector3 (1, 0, 0);
		var xPosition = transform.position.x;

		if (left && xPosition > -15)
		{			
			transform.position = transform.position - moveVector;
		}
		if (right && xPosition < 15) {
			transform.position = transform.position + moveVector;
		}
	}
}
