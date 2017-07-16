﻿﻿using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner 
{
    private GameObject[] _prefabs;
    public int TopPositionToSpawn;

    public ObstacleSpawner()
    {
        TopPositionToSpawn = 12;
        Object[] prefabs = Resources.LoadAll("Prefabs/");

        if (prefabs != null)
        {
            _prefabs = prefabs.ToList().Where(p => p is GameObject && ((GameObject)p).tag.Equals("Scenario"))
                              .Select(p => (GameObject)p).ToArray();
        }
    }
	
	// Update is called once per frame
    public void SpawnObstacle()
    {
        Vector3 position = new Vector3(0, TopPositionToSpawn, 0);
        int length = _prefabs.Length;

        if (length > 1)
        {
            System.Random rnd = new System.Random();
            int index = rnd.Next(2, length);
            index--;

            GameObject obj = GameObject.Instantiate(_prefabs[index], position, _prefabs[index].transform.rotation);
        }
    }
}