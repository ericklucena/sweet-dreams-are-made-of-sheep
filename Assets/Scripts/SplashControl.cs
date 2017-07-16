using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        TouchControls();
        KeyboardControls();
	}

	void TouchControls()
	{
		if (Input.touchCount > 0)
		{
            SceneManager.LoadScene("MainGame");
		}
	}

	void KeyboardControls()
	{
        if (Input.anyKeyDown)
		{
			SceneManager.LoadScene("MainGame");
		}
	}
}
