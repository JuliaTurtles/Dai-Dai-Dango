using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComicScreenManager : MonoBehaviour {
	public void LoadMenu(){
		SceneManager.LoadScene ("Play Game");
	}
	public void LoadPrologueScreen(){
		SceneManager.LoadScene ("Prologue Screen");
	}
	public void LoadChapterScreen(){
		SceneManager.LoadScene ("Chapter One Screen");
	}
	public void LoadViewComics(){
		SceneManager.LoadScene ("Comics Screen");
	}
}
