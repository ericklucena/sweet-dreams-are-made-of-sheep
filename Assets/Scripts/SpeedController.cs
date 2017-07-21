using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour {

    public int StartSpeed = 1;
    public int IntervalInSeconds = 20;
    private DateTime _init;
    private int _clock;

	// Use this for initialization
	void Start () {
        _init = DateTime.Now;
        GameController.Instance.Speed = StartSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        TimeSpan time = DateTime.Now - _init;
        double total = time.TotalSeconds;

        if (total > IntervalInSeconds)
        {
            _init = DateTime.Now;
            GameController.Instance.Speed++;
        }
	}
}