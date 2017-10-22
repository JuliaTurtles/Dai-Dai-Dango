using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
	public GameObject[] availableScreens;
	public List<GameObject> currentScreens;
	private float screenHeightInPoints;

	// Use this for initialization
	void Start () {
		screenHeightInPoints = 2.0f * Camera.main.orthographicSize;
	}

	// Update is called once per frame

	void Update () {

	}
	void AddScreen(float farthestScreenEndY)
	{
		//1
		int randomScreenIndex = Random.Range(0, availableScreens.Length);

		//2
		GameObject screen = (GameObject)Instantiate(availableScreens[randomScreenIndex]);

		//3
		float screenHeight = screen.transform.Find("wallLeft").localScale.y;

		//4
		float screenCenter = farthestScreenEndY + screenHeight * 0.5f;

		//5
		screen.transform.position = new Vector3(screenCenter, 0, 0);

		//6
		currentScreens.Add(screen);         
	} 
	void GenerateScreenIfRequired()
	{
		//1
		List<GameObject> screensToRemove = new List<GameObject>();

		//2
		bool addScreens = true;        

		//3
		float playerY = transform.position.y;

		//4
		float removeScreenY = playerY - screenHeightInPoints;        

		//5
		float addScreenY = playerY + screenHeightInPoints;

		//6
		float farthestScreenEndY = 0;

		foreach(var screen in currentScreens)
		{
			//7

			float screenHeight = screen.transform.Find("wallLeft").localScale.y;
			float screenStartY = screen.transform.position.y - (screenHeight * 0.5f);    
			float screenEndY = screenStartY + screenHeight;                            
			Debug.Log("addScreenY");
			Debug.Log (addScreenY);
			Debug.Log ("screenStartY");
			Debug.Log (screenStartY);
			Debug.Log ("screenEndY");
			Debug.Log (screenEndY);

			//8
			if (screenStartY > addScreenY)
				addScreens = false;

			//9
			if (screenEndY < removeScreenY)
				screensToRemove.Add(screen);

			//10
			farthestScreenEndY = Mathf.Max(farthestScreenEndY, screenEndY);
		}

		//11
		foreach(var screen in screensToRemove)
		{
			currentScreens.Remove(screen);
			Destroy(screen);            
		}

		//12
		if (addScreens)
			AddScreen(farthestScreenEndY);
	}

	void FixedUpdate () 
	{    
		GenerateScreenIfRequired();
	}
}
