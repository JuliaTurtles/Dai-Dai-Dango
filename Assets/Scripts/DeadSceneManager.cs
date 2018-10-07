using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadSceneManager : MonoBehaviour {
	public Button playAgainButton;

	// Use this for initialization
	void Start () {
		playAgainButton.interactable = false;
		StartCoroutine (LoadLevelAfterDelay (1f));
	}
	
	IEnumerator LoadLevelAfterDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
		print ("Delayed!");
		playAgainButton.interactable = true;
	}
}
