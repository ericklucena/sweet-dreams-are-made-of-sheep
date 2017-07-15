using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController
{
    public int Speed { get; set; }

	public static GameController Instance
	{
		get
		{
			if (_instance == null)
				_instance = new GameController();

			return _instance;
		}
	}

    public GameController(){
        Speed = 1;
    }

	private static GameController _instance;
}