using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodController : MonoBehaviour {

    public int TopPositionToSpawn;
    private ObstacleSpawner _spawner;

    void Start()
    {
        _spawner = new ObstacleSpawner();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Scenario")){
            _spawner.SpawnObstacle(TopPositionToSpawn);
        }
        else {
            Destroy(collision.gameObject);
        }
    }
}