using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DangoScore : MonoBehaviour {

	public string dangoName;

	// Use this for initialization
	void Start () {
		var scoreText = gameObject.GetComponent<Text> ();
		var score = PlayerPrefs.GetInt (dangoName);
		scoreText.text = score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
