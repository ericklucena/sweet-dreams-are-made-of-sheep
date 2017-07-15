using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftSpawner : MonoBehaviour
{
	public GameObject ObjectToSpawn;
	public UnityEngine.Events.UnityEvent OnSpawn;
    public int RandomVariation;
    public int TopPositionToSpawn;

    public void Spawn()
    {       
        List<UnityEngine.GameObject> objects = GameObject.FindGameObjectsWithTag("Obstacle").ToList();

		System.Random rnd = new System.Random();
        int xposition = rnd.Next(-RandomVariation, RandomVariation);
        Vector3 position = new Vector3(xposition, TopPositionToSpawn, 0);

        if (!objects.Any(o => o.transform.position.Equals(position)))
        {
            var obj = GameObject.Instantiate(ObjectToSpawn, position, ObjectToSpawn.transform.rotation);
            OnSpawn.Invoke();
        }
    }
}