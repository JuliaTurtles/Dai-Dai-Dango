using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private int score;
	public int health;
	public GameSceneManager sceneManager;

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int getScore() {
		return score;
	}
	public int getHealth() {
		return health;
	}

	public void addPoint() {
		score = score + 1;
		Debug.Log ("New score: " + score);
	}
	public void removeHealth() {
		health = health - 1;
		if (health == 0) {
			sceneManager.LoadEndGame ();
		}
	}
}
