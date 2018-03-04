using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangoMaker : MonoBehaviour {
	public List<GameObject> dangos;
	public float dangoRate = 1;
	private float timeSinceLastDango = 0;
	private HandController hand;
	public GameObject octopus;
	private int numberOfDangos;
	private Player player;

	// Use this for initialization
	void Start () {
		hand = GameObject.Find ("Hand").GetComponent<HandController> ();
		player = GameObject.Find ("Player").GetComponent<Player> ();
		numberOfDangos = dangos.Count;

	}

	void FixedUpdate () {
		if (timeSinceLastDango > dangoRate) {
			CreateDango ();
			timeSinceLastDango = 0;
		} else {
			timeSinceLastDango = timeSinceLastDango + Time.fixedDeltaTime;
		}
		var score = player.getScore ();
		var numberOfOctopai = dangos.Count - numberOfDangos;
		var expectedOctopai = score / 20 + 1;
		if (expectedOctopai > numberOfOctopai) {
			dangos.Add (octopus);
		}
	}

	void CreateDango () {
		float xCoordinate = (Random.value * 30.0f) - 15.0f;
		float yCoordinate = 32.0f + hand.getHeight();
		int dangoIndex = Random.Range (0, dangos.Count);
		GameObject dango = (GameObject)Instantiate (dangos [dangoIndex]);
		dango.transform.position = new Vector3 (xCoordinate, yCoordinate, -1);
	}
}
