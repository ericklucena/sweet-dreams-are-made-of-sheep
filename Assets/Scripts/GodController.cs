using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodController : MonoBehaviour {

    private ObstacleSpawner _spawner;

    void Start()
    {
        _spawner = new ObstacleSpawner();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Scenario")){
            _spawner.SpawnObstacle();
        }
        else if (collision.tag.Equals("Obstacle")){
            Destroy(collision.gameObject);
        }
    }
}