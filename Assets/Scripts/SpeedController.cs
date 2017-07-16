using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour {

    private DateTime _init;
    private int _clock;

	// Use this for initialization
	void Start () {
        _clock = 1;
        _init = DateTime.Now;
	}
	
	// Update is called once per frame
	void Update () {
        TimeSpan time = DateTime.Now - _init;
        double total = time.TotalMinutes;

        if (total > _clock)
        {
            _clock++;
            GameController.Instance.Speed++;
        }
	}
}