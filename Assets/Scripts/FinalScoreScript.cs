using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreScript : MonoBehaviour {

	public Text gameText;

    private const string POINTS_FORMAT = "{0}";

	// Use this for initialization
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		gameText.text = string.Format(POINTS_FORMAT, GameController.Instance.TotalPoints);
	}
}
