using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var scoreText = gameObject.GetComponent<Text> ();
		var score = PlayerPrefs.GetInt ("score");
		var highScore = PlayerPrefs.GetInt ("high score");
		scoreText.text = "your score is " + score + "\nyour high score is " + highScore;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
