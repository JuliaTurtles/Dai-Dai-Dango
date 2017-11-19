using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private int score;

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

	public void addPoint() {
		score = score + 1;
		Debug.Log ("New score: " + score);
	}
}
