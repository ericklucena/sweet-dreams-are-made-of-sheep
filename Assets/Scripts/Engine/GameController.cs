﻿﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController
{
    public int Speed { get; set; }
    public float XCenter { get; private set; }
    public float XLeft { get; private set; }
    public float XRight { get; private set; }

    public bool Playing { get; set; }

    public int TimePoints { get; private set; }
	public int SheepPoints { get; set; }
    public int TotalPoints { get { return TimePoints + SheepPoints; }}
    public float Sleepness { get; private set; }
    public float InitTime { get; private set; }

    public bool Running { get; private set; }

    private const int POINTS_PER_SHEEP = 10;

    public static GameController Instance
    {
        get
        {
            if (_instance == null)
                _instance = new GameController();

            return _instance;
        }
    }

    public GameController()
    {
        Playing = true;

        if (Speed == 0)
            Speed = 1;
        
        XCenter = 0;
        XRight = -3.5f;
        XLeft = 3.5f;

        Sleepness = 0.5f;
        ResetTime();
        SheepPoints = 0;
    }

    private static GameController _instance;

    public void RestartAfterDeath()
    {
        _instance = new GameController();

	}

    public void AddSheepPoint()
    {
        if (Running)
        {
			SheepPoints += POINTS_PER_SHEEP;

            if (Sleepness < 1)
			    Sleepness += 0.25f;

            if (Sleepness > 1)
                Sleepness = 1;
        }

    }

	public void RemoveSheepPoint()
	{
		if (Running) 
        {
			Sleepness -= 0.12f;
        }

	}

    public void RefreshTimePoints() {
        if (Running)
        {
			TimePoints = (int) ((Time.time - InitTime) * 10);
            Sleepness -= 0.001f;         
        }


        if (Sleepness < 0) {
            SceneManager.LoadScene("ScoreScene");
        }



    }

    public void ResetTime()
    {
        InitTime = Time.time;
    }

    public void StartGame(){
        Running = true;
    }

	public void StopGame()
	{
        Running = false;
	}

}