﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dango : MonoBehaviour {
	private bool connected;

	// Use this for initialization
	void Start () {
		connected = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -35.0) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		var contactPoint = collision.contacts [0].point;
		var center = collision.collider.bounds.center;
		var topCollision = contactPoint.y > center.y;

		if (collision.gameObject.tag != "Wall" && !connected && topCollision) {
			this.transform.position = new Vector3 (collision.collider.bounds.center.x, this.transform.position.y, this.transform.position.z);
			var fixedJoint = collision.gameObject.AddComponent<FixedJoint2D> ();
			fixedJoint.connectedBody = gameObject.GetComponent<Rigidbody2D>();
			fixedJoint.autoConfigureConnectedAnchor = false;
			fixedJoint.enableCollision = false;

			var otherCollider = collision.gameObject.GetComponent<BoxCollider2D> ();
			Destroy (otherCollider);


			connected = true;
		}
	}

}