using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour {
	public GameObject life1;
	public GameObject life2;
	public GameObject life3;
	private Player player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
		var health = player.getHealth ();
		if (health < 3) {
			life1.SetActive (false);
		}
		if (health < 2) {
			life2.SetActive (false);
		}
		if (health < 1) {
			life3.SetActive (false);
		}
	}
}
