using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangoTracker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public static void trackDango (GameObject dango) {
		var count = PlayerPrefs.GetInt (dango.name, 0);
		PlayerPrefs.SetInt (dango.name, count + 1);
		print (dango.name + ": " + (count + 1));
	}
}
