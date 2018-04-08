using System.Collections;
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
		if (collision.contacts.Length == 0) {
			return;
		}
		var contactPoint = collision.contacts[0].point;
		var center = collision.collider.bounds.center;
		var topCollision = contactPoint.y > center.y;

		if (collision.gameObject.tag == "Connected" && !connected && topCollision) {
			var otherCollider = collision.gameObject.GetComponent<BoxCollider2D> ();
			this.transform.position = new Vector3 (
				collision.collider.bounds.center.x,
				collision.collider.bounds.center.y + collision.collider.bounds.extents.y*2,
				this.transform.position.z
			);
			var fixedJoint = collision.gameObject.AddComponent<FixedJoint2D> ();
			fixedJoint.connectedBody = gameObject.GetComponent<Rigidbody2D>();
			fixedJoint.autoConfigureConnectedAnchor = false;
			fixedJoint.enableCollision = false;
			fixedJoint.frequency = 0;
			gameObject.tag = "Connected";

			Destroy (otherCollider);

			var player = getPlayer ();
			player.addPoint ();

			var hand = getHand ();
			hand.addDango (gameObject, transform.position.y - collision.transform.position.y);

			var rigidBody = GetComponent<Rigidbody2D> ();

			rigidBody.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

			connected = true;
		}
	}

	private Player getPlayer() {
		return GameObject.Find ("Player").GetComponent<Player>();
	}

	private HandController getHand() {
		return GameObject.Find ("Player").GetComponent<HandController> ();
	}
}
