using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour {
	public void LoadGame(){
		SceneManager.LoadScene("Dai Dai Dango");
	}
	public void LoadEndGame(){
		SceneManager.LoadScene ("Dead Scene");
	}
}
