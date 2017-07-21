﻿using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner 
{
    private GameObject[] _prefabs;

    public ObstacleSpawner()
    {
        Object[] prefabs = Resources.LoadAll("Prefabs/");

        if (prefabs != null)
        {
            _prefabs = prefabs.ToList().Where(p => p is GameObject && ((GameObject)p).tag.Equals("Scenario"))
                              .Select(p => (GameObject)p).ToArray();
        }
    }
	
	// Update is called once per frame
    public void SpawnObstacle(int topPositionToSpawn)
    {
        Vector3 position = new Vector3(0, topPositionToSpawn, 0);
        int length = _prefabs.Length;

        if (length > 1)
        {
            System.Random rnd = new System.Random();
            int index = rnd.Next(2, length+1);
            index--;

            GameObject obj = GameObject.Instantiate(_prefabs[index], position, _prefabs[index].transform.rotation);
        }
    }
}