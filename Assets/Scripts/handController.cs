using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour {
	private float height;
	private List<GameObject> connectedObjects;

	// Use this for initialization
	void Start () {
		height = 0;
		connectedObjects = new List<GameObject> ();
	}
	// Update is called once per frame
	void Update () {

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

	public float getHeight () {
		return height;
	}
	public void addDango(GameObject dango, float dangoHeight) {
		height += dangoHeight;
		connectedObjects.Add (dango);
	}
}
