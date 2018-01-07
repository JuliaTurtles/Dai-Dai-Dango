using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangoMaker : MonoBehaviour {
	public GameObject[] dangos;
	public float dangoRate = 1;
	private float timeSinceLastDango = 0;
	private GameController hand;

	// Use this for initialization
	void Start () {
		hand = GameObject.Find ("Game Controller").GetComponent<GameController> ();
	}

	void FixedUpdate () {
		if (timeSinceLastDango > dangoRate) {
			CreateDango ();
			timeSinceLastDango = 0;
		} else {
			timeSinceLastDango = timeSinceLastDango + Time.fixedDeltaTime;
		}
	}

	void CreateDango () {
		float xCoordinate = (Random.value * 30.0f) - 15.0f;
		float yCoordinate = 32.0f + hand.getHeight();
		int dangoIndex = Random.Range (0, dangos.Length);
		GameObject dango = (GameObject)Instantiate (dangos [dangoIndex]);
		dango.transform.position = new Vector3 (xCoordinate, yCoordinate, -1);
	}
}
