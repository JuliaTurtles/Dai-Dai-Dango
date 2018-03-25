using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	private Player player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
		var scoreText = gameObject.GetComponent<Text> ();
		scoreText.text = player.getScore ().ToString();
	}
}
