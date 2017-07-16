using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text gameText;

    private const string POINTS_FORMAT = "Points: {0}";

	// Use this for initialization
	void Start () {
        GameController.Instance.StartGame();
	}
	
	// Update is called once per frame
	void Update () {
        gameText.text = string.Format(POINTS_FORMAT, GameController.Instance.TotalPoints);
	}
}
